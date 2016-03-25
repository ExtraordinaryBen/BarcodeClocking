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
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace BarcodeClocking
{
    public partial class FormEditCard : Form
    {
        // vars
        private char[] invalidChars;
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;

        public FormEditCard()
        {
            InitializeComponent();

            // get list of invalid chars for system
            invalidChars = Path.GetInvalidFileNameChars();

        }

        private void TextBoxCardID_KeyDown(object sender, KeyEventArgs e)
        {
            // vars
            bool found = false;

            // check for user or scanner 'pressing' enter
            if (e.KeyData.ToString().Equals("Return"))
            {
                // don't let the textbox handle it further
                e.SuppressKeyPress = true;

                // don't allow changing the card id
                TextBoxCardID.ReadOnly = true;

                dt = sql.GetDataTable("select * from employees where employeeID="+TextBoxCardID.Text.Trim()+ ";");

                // check if this is the card we're looking for
                if (dt.Rows.Count == 1)
                {
                    // make note of card's position
                    found = true;

                    // enable editing and saving
                    TextBoxFirstName.Enabled = true;
                    TextBoxLastName.Enabled = true;
                    TextBoxMI.Enabled = true;
                    NumericUpDownHrRate.Enabled = true;
                    RadioButtonFWS.Enabled = true;
                    RadioButtonSWS.Enabled = true;
                    RadioButtonMST.Enabled = true;
                    RadioButtonHED.Enabled = true;
                    RadioButtonHelp.Enabled = true;
                    RadioButtonTutor1.Enabled = true;
                    RadioButtonTutor2.Enabled = true;
                    RadioButtonTANF.Enabled = true;
                    ButtonSave.Enabled = true;

                    try
                    {
                        // first name
                        TextBoxFirstName.Text = dt.Rows[0].ItemArray[1].ToString();

                        // last name
                        TextBoxLastName.Text = dt.Rows[0].ItemArray[2].ToString();

                        // middle initial
                        TextBoxMI.Text = dt.Rows[0].ItemArray[3].ToString();

                        // hourly rate
                        NumericUpDownHrRate.Value = Decimal.Parse(dt.Rows[0].ItemArray[4].ToString());

                        // position type
                        switch (dt.Rows[0].ItemArray[5].ToString())
                        {
                            case "FWS": RadioButtonFWS.Checked = true;
                                break;
                            case "SWS": RadioButtonSWS.Checked = true;
                                break;
                            case "MST": RadioButtonMST.Checked = true;
                                break;
                            case "HED": RadioButtonHED.Checked = true;
                                break;
                            case "Help": RadioButtonHelp.Checked = true;
                                break;
                            case "Tutor1": RadioButtonTutor1.Checked = true;
                                break;
                            case "Tutor2": RadioButtonTutor2.Checked = true;
                                break;
                            case "TANF": RadioButtonTANF.Checked = true;
                                break;
                        }

                        // automatically go to the next text box
                        TextBoxFirstName.Focus();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(this, "There was an error while trying to load your info.\nWas someone playing with the database files?\n\n" + err.Message, "Clocked Time Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                // notify user if card wasn't found
                if (!found)
                {
                    MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxCardID.Clear();
                    TextBoxCardID.ReadOnly = false;
                    TextBoxCardID.Focus();
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // vars
            string posType = "";

            // check for blank first name
            if (TextBoxFirstName.Text.Length == 0)
            {
                if (MessageBox.Show(this, "Are you sure you don't want to provide a first name?\nIf yes, your card ID will be used instead.", "Empty First Name", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    TextBoxFirstName.Text = TextBoxCardID.Text;
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

            try
            {
                Dictionary<String, String> data = new Dictionary<String, String>();
                data.Add("firstName", TextBoxFirstName.Text);
                data.Add("lastName", TextBoxLastName.Text);
                data.Add("MiddleName", TextBoxMI.Text);
                data.Add("hourlyRate", NumericUpDownHrRate.Value.ToString() );
                data.Add("employeeType", posType);

                sql.Update("employees", data, String.Format("employees.employeeID = {0}", TextBoxCardID.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "There was an error while trying to save the card info edits.\nWas someone playing with the database files?\n\n" + err.Message, "Clocked Time Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // close
            ButtonSave.Enabled = false;
            this.Close();
        }

        private void FormEditCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check for unsaved edits
            if (ButtonSave.Enabled)
            {
                // ask user if they want to save edits
                if (MessageBox.Show(this, "Are you sure you want to close? Any unsaved changes will be lost.", "Unsaved Card Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}