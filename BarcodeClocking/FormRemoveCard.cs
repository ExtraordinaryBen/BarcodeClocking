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
    public partial class FormRemoveCard : Form
    {
        // vars
        private char[] invalidChars;
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;

        public FormRemoveCard()
        {
            InitializeComponent();

            // get list of invalid chars for system
            invalidChars = Path.GetInvalidFileNameChars();

        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            // vars
            bool found = false;

            dt = sql.GetDataTable("select * from employees where employeeID=" + TextBoxCardID.Text.Trim() + ";");

            // check if this is the card we're looking for
            if (dt.Rows.Count == 1)
            {
                // mark as found
                found = true;

                // confirm deletion of card
                if (MessageBox.Show(this, "Are you sure you want to delete " + dt.Rows[0].ItemArray[1].ToString() + "'s card?\n(Card/Student ID: " + dt.Rows[0].ItemArray[0].ToString() + ")", "Confirm Card Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    // write to file
                    try
                    {
                        sql.Delete("employees", String.Format("employeeID = {0}", dt.Rows[0].ItemArray[0].ToString()));
                        if(CheckBoxDelTimeLog.Checked == true)
                            sql.Delete("timeStamps", String.Format("employeeID = {0}", dt.Rows[0].ItemArray[0].ToString()));

                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(this, "There was an error while trying to remove the card.\n\n" + err.Message, "File Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }

            // notify user if card wasn't found
            if (!found)
                MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // reset text box
            TextBoxCardID.Clear();
            TextBoxCardID.Focus();
        }
    }
}