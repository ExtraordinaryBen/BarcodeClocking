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
using System.Data;

namespace BarcodeClocking
{
    public partial class FormAddTime : Form
    {
        // vars
        private char[] invalidChars;
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;

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
                // check for user or scanner 'pressing' enter
                if (e.KeyData.ToString().Equals("Return"))
                {
                    // don't let the textbox handle it further
                    e.SuppressKeyPress = true;

                    // don't allow changing the card id
                    TextBoxCardID.ReadOnly = true;

                    // notify user if card wasn't found
                    if ( !(Helper.EmployeeExists(TextBoxCardID.Text, sql)) )
                    {
                        MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // enable editing of card id
                        TextBoxCardID.ReadOnly = false;
                        TextBoxCardID.Focus();
                        TextBoxCardID.SelectAll();
                    }
                    else 
                        // move on to next control
                        DateTimePickerIn.Focus();
                }
            }
            catch (Exception err)
            {
                TextBoxCardID.ReadOnly = false;
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

            // check for card id being validated
            if (!TextBoxCardID.ReadOnly)
            {
                // validate card
                try
                {
                    // vars
                    bool found = false;

                    // don't allow changing the card id
                    TextBoxCardID.ReadOnly = true;

                    // confirm card was found
                    if ( !(Helper.EmployeeExists(TextBoxCardID.Text, sql)) )
                    {
                        // display notification
                        MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // enable editing of card id
                        TextBoxCardID.ReadOnly = false;
                        TextBoxCardID.Focus();
                        TextBoxCardID.SelectAll();

                        // prevent further processing
                        return;
                    }
                }
                catch (Exception err)
                {
                    // enable editing of card id
                    TextBoxCardID.ReadOnly = false;

                    // display error
                    MessageBox.Show(this, "There was an error while trying to make sure the card was recognized.\n\n" + err.Message, "Load Card List Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // prevent further processing
                    return;
                }
            }

            try
            {
                Dictionary<String, String> data = new Dictionary<String, String>();
                data.Add("employeeID", TextBoxCardID.Text.Trim());
                data.Add("clockIn", DateTimePickerIn.Value.ToString(StringFormats.sqlTimeFormat));
                data.Add("clockOut", DateTimePickerOut.Value.ToString(StringFormats.sqlTimeFormat));

                sql.Insert("timeStamps", data);
            
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