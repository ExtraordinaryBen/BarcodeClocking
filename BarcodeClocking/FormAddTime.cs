// Copyright © 2015 Lower Columbia College Computer Science Club

// This file is part of Barcode Clocking.

// Barcode Clocking is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Barcode Clocking is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.

// You should have received a copy of the GNU Affero General Public License
// along with Barcode Clocking.  If not, see <http://www.gnu.org/licenses/>.

// If you have any questions or comments, please contact the current Club
// President or Club Vice President.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BarcodeClocking
{
    public partial class FormAddTime : Form
    {
        // vars
        private char[] invalidChars;

        public FormAddTime()
        {
            InitializeComponent();

            // get list of invalid chars for system
            invalidChars = Path.GetInvalidFileNameChars();

            // set date/time picker values to now
            DateTimePickerIn.Value = DateTime.Now;
            DateTimePickerOut.Value = DateTime.Now;
        }

        private void TextBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // vars
                bool found = false;
                string[] currentFile;

                // check for user or scanner 'pressing' enter
                if (e.KeyData.ToString().Equals("Return"))
                {
                    // load cards
                    currentFile = File.ReadAllLines("cardList.txt");

                    // don't let the textbox handle it further
                    e.SuppressKeyPress = true;

                    // don't allow changing the card id
                    TextBoxID.ReadOnly = true;

                    // find respective card
                    for (int i = 0; i < currentFile.Length; i++)
                    {
                        // check if this is the card we're looking for
                        if (currentFile[i].Split(new char[] { '\t' })[0].Equals(TextBoxID.Text.Trim()))
                            // make note
                            found = true;
                    }

                    // notify user if card wasn't found
                    if (!found)
                    {
                        MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // enable editing of card id
                        TextBoxID.ReadOnly = false;
                        TextBoxID.Focus();
                        TextBoxID.SelectAll();
                    }
                    else
                        // move on to next control
                        DateTimePickerIn.Focus();
                }
            }
            catch (Exception err)
            {
                TextBoxID.ReadOnly = false;
                MessageBox.Show(this, "There was an error while trying to make sure the card was recognized.\n\n" + err.Message, "Load Card List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DateTimePickerIn_ValueChanged(Object sender, EventArgs e)
        {
            DateTimePickerOut.MinDate = DateTimePickerIn.Value;
            DateTimePickerOut.Value = DateTimePickerIn.Value;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // vars
            string[] oldFile;
            List<string> newFile = new List<string>();

            // check for card id being validated
            if (!TextBoxID.ReadOnly)
            {
                // validate card
                try
                {
                    // vars
                    bool found = false;
                    string[] currentFile = File.ReadAllLines("cardList.txt");

                    // load cards
                    currentFile = File.ReadAllLines("cardList.txt");

                    // don't allow changing the card id
                    TextBoxID.ReadOnly = true;

                    // find respective card
                    for (int i = 0; i < currentFile.Length; i++)
                    {
                        // check if this is the card we're looking for
                        if (currentFile[i].Split(new char[] { '\t' })[0].Equals(TextBoxID.Text.Trim()))
                        {
                            // make note
                            found = true;

                            // stop looking for card
                            break;
                        }
                    }

                    // confirm card was found
                    if (!found)
                    {
                        // display notification
                        MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // enable editing of card id
                        TextBoxID.ReadOnly = false;
                        TextBoxID.Focus();
                        TextBoxID.SelectAll();

                        // prevent further processing
                        return;
                    }
                }
                catch (Exception err)
                {
                    // enable editing of card id
                    TextBoxID.ReadOnly = false;

                    // display error
                    MessageBox.Show(this, "There was an error while trying to make sure the card was recognized.\n\n" + err.Message, "Load Card List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // prevent further processing
                    return;
                }
            }

            try
            {
                // get current time log
                oldFile = File.ReadAllLines(TextBoxID.Text.Trim() + ".txt");

                // go through each line of file
                foreach (string line in oldFile)
                {
                    // make sure this line has two values (don't interfere with current clock-in)
                    if (line.Split(new char[] { '\t' })[1].Length > 0)
                        // add line to new file
                        newFile.Add(line + "\r\n");
                }

                // add new clock-in/-out entry
                newFile.Add(DateTimePickerIn.Value.ToBinary().ToString() + "\t" + DateTimePickerOut.Value.ToBinary().ToString() + "\r\n");

                // check for last line having one value (current clock-in)
                if (oldFile[oldFile.Length - 1].Split(new char[] { '\t' })[1].Length == 0)
                    // add line to new file
                    newFile.Add(oldFile[oldFile.Length - 1]);

                // write new file to disk
                // note: we can't use File.WriteAllLines() because it adds an extra \r\n to the end of the file (this is bad)
                File.Delete(TextBoxID.Text.Trim() + ".txt");
                for (int i = 0; i < newFile.Count; i++)
                    // write line
                    File.AppendAllText(TextBoxID.Text.Trim() + ".txt", newFile[i]);
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "There was an error while trying to save your additional time to your time log file.\n\n" + err.Message, "Add Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // close form
            this.Close();
        }

    }
}