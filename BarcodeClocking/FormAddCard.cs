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
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace BarcodeClocking
{
    public partial class FormAddCard : Form
    {
        // vars
        private char[] invalidChars;
        private SQLiteDatabase sql = new SQLiteDatabase();

        public FormAddCard()
        {
            InitializeComponent();

            // get list of invalid chars for system
            invalidChars = Path.GetInvalidFileNameChars();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // vars
            bool containsInvalidChar = false;
            string finalCardID = TextBoxCardID.Text.Trim();
            string posType = "";

            // check for invalid chars
            foreach (char invalidChar in invalidChars)
            {
                if (finalCardID.IndexOf(invalidChar) != -1)
                {
                    containsInvalidChar = true;
                    finalCardID.Replace(invalidChar, '_');
                }
            }

            // if there was an invalid char, notify user of ID used in app
            if (containsInvalidChar)
            {
                if (MessageBox.Show(this, "Your card ID format contains invalid characters for use in this program. In the future, when your card is scanned, it will be seen as " + finalCardID + " instead of " + TextBoxCardID.Text + ".", "Card ID Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                    return;
            }

            // check for blank first name
            if (TextBoxFirstName.Text.Length == 0)
            {
                if (MessageBox.Show(this, "Are you sure you don't want to provide a first name?\nIf yes, your card ID will be used instead.", "Empty First Name", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    TextBoxFirstName.Text = finalCardID;
            }

            // set position type if applicable
            if (RadioButtonFWS.Checked)
                posType = "FWS";
            else if (RadioButtonSWS.Checked)
                posType = "SWS";
            else if (RadioButtonMST.Checked)
                posType = "MST";
            else if (RadioButtonHED.Checked)
                posType = "HED";
            else if (RadioButtonHelp.Checked)
                posType = "Help";
            else if (RadioButtonTutor1.Checked)
                posType = "Tutor1";
            else if (RadioButtonTutor2.Checked)
                posType = "Tutor2";
            else if (RadioButtonTANF.Checked)
                posType = "TANF";

            // verify card ID doesn't already exist
            if (sql.GetDataTable("select * from employees where employeeID="+TextBoxCardID.Text.Trim()+ ";").Rows.Count > 0)
            {
                MessageBox.Show(this, "The Card ID you entered already exists! Please make sure it was entered correctly.", "Duplicate Card ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            try
            {
                Dictionary<String, String> data = new Dictionary<String, String>();
                data.Add("employeeID", TextBoxCardID.Text);
                data.Add("firstName", TextBoxFirstName.Text);
                data.Add("lastName", TextBoxLastName.Text);
                data.Add("MiddleName", TextBoxMI.Text);
                data.Add("hourlyRate", NumericUpDownHrRate.Value.ToString());
                data.Add("employeeType", posType);
                data.Add("currentClockInId", "0");

                sql.Insert("employees", data);
            }
            catch (Exception error)
            {
                MessageBox.Show("Something went horribly wrong while trying to save your profile!\n" + error.Message);
            }

            this.Close();
        }

        private void TextBoxCardID_KeyDown(object sender, KeyEventArgs e)
        {
            // check for user or scanner 'pressing' enter
            if (e.KeyData.ToString().Equals("Return"))
            {
                // don't let the textbox handle it further
                e.SuppressKeyPress = true;

                // automatically go to the next text box
                TextBoxFirstName.Focus();
            }
        }
    }
}