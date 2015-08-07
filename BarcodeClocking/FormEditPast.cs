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
using System.Collections.Generic;

namespace BarcodeClocking
{
    public partial class FormEditPast : Form
    {
        // vars
        private char[] invalidChars;
        private string originalDateTimeStr;
        private List<int> positionMapper;
        private List<TimeCombo> timeList;
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;

        public FormEditPast()
        {
            InitializeComponent();

            // set month and year selection
            ComboBoxMonth.SelectedIndex = DateTime.Today.Month - 1;
            NumericUpDownYear.Value = DateTime.Today.Year;

            // get list of invalid chars for system, excluding backspace
            List<char> tempList = Path.GetInvalidFileNameChars().ToList();
            tempList.Remove('\b');
            invalidChars = tempList.ToArray();

        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            // vars
            bool found = false;
            timeList = new List<TimeCombo>();
            positionMapper = new List<int>();

            // change gui
            ButtonLoad.Text = "Loading Times...";
            ButtonLoad.Enabled = false;
            TextBoxCardID.Enabled = false;
            ComboBoxMonth.Enabled = false;
            NumericUpDownYear.Enabled = false;
            DataGridViewTimes.Rows.Clear();

            // get month beginning and end
            DateTime monthStart = new DateTime((int)NumericUpDownYear.Value, ComboBoxMonth.SelectedIndex + 1, 1);
            DateTime monthEnd = monthStart.AddMonths(1);


            dt = sql.GetDataTable("select strftime('%m/%d/%Y %H:%M:%S', clockIn) as clockIn, strftime('%m/%d/%Y %H:%M:%S', clockOut) as clockOut "
                + "from timeStamps where employeeID=" + TextBoxCardID.Text.Trim()
                + " and cast(strftime('%m', clockIn) as integer) = " + (int)(ComboBoxMonth.SelectedIndex + 1)
                + " and cast(strftime('%Y', clockIn) as integer) = " + (int)NumericUpDownYear.Value + ";");

            // check if this is the card we're looking for
            if (dt.Rows.Count > 0)
            {
                // mark as found
                found = true;

                try
                {

                    DataGridViewTimes.DataSource = dt;
                    this.DataGridViewTimes.ClearSelection();
                    this.DataGridViewTimes.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridViewTimes_RowStateChanged);
                    clockInTimePicker.Enabled = true;
                    clockOutTimePicker.Enabled = true;
                    datePicker.Enabled = true;

                }
                catch (Exception err)
                {
                    MessageBox.Show(this, "There was an error while trying to load your clocked times.\n\n" + err.Message, "Times Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // enable controls
                    TextBoxCardID.Enabled = true;
                    ComboBoxMonth.Enabled = true;
                    NumericUpDownYear.Enabled = true;
                    DataGridViewTimes.DataSource = null;
                    ButtonLoad.Enabled = true;
                    ButtonSave.Enabled = false;
                }

            }


            // notify user if card wasn't found
            if (!found)
            {
                MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // reset gui
                TextBoxCardID.Enabled = true;
                ComboBoxMonth.Enabled = true;
                NumericUpDownYear.Enabled = true;
                DataGridViewTimes.DataSource = null;
                ButtonLoad.Enabled = true;
                ButtonSave.Enabled = false;
            }
            // check for no times showing
            else if (DataGridViewTimes.Rows.Count == 0)
            {
                // notify user
                MessageBox.Show(this, "It looks like there isn't any time you logged in the selected month. Are you sure the year and month selections are correct?", "No Times", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // reset gui
                TextBoxCardID.Enabled = true;
                ComboBoxMonth.Enabled = true;
                NumericUpDownYear.Enabled = true;
                DataGridViewTimes.DataSource = null;
                ButtonLoad.Enabled = true;
                ButtonSave.Enabled = false;
            }

            // change 'status'
            ButtonLoad.Text = "Load Times";
        }

        private void DataGridViewTimes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            datePicker.Value = DateTime.Parse(e.Row.Cells[0].Value.ToString());
            clockInTimePicker.Value = DateTime.Parse(e.Row.Cells[0].Value.ToString());
            clockOutTimePicker.Value = DateTime.Parse(e.Row.Cells[1].Value.ToString());

            // enable saving
            ButtonSave.Enabled = true;
        }

        private void DataGridViewTimes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // record original string
            originalDateTimeStr = DataGridViewTimes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            // enable saving
            ButtonSave.Enabled = true;
        }

        private void DataGridViewTimes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // check to make sure value is in a correct fomat
            try
            {
                // check for which value was changed 
                if (e.ColumnIndex == 0)
                    // save new clocked in time
                    timeList[positionMapper[e.RowIndex]].clockedIn = DateTime.Parse(DataGridViewTimes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else if (e.ColumnIndex == 1)
                    // save new clocked out time
                    timeList[positionMapper[e.RowIndex]].clockedOut = DateTime.Parse(DataGridViewTimes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
            catch (Exception err)
            {
                // show error to user
                MessageBox.Show(this, "There was an error while checking the value you entered for the date and time. Please make sure it is in the correct format, and that it's a valid date and time.\n\nMore details:\n" + err.Message, "Incorrect Date/Time", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // change value back to original
                DataGridViewTimes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = originalDateTimeStr;
            }
        }

        private void DataGridViewTimes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // remove respective row from list of clocked times
            //timeList.RemoveAt(positionMapper[e.RowIndex]);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            // make sure nothing needs to be saved
            if (ButtonSave.Enabled)
            {
                // switch on user choice
                switch (MessageBox.Show(this, "There are unsaved changes. Would you like to save them before resetting this window?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
                {
                    case DialogResult.Yes: ButtonSave_Click(sender, e);
                        break;
                    case DialogResult.Cancel: return;
                }

            }

            // reset gui
            TextBoxCardID.Clear();
            TextBoxCardID.Enabled = true;
            ComboBoxMonth.SelectedIndex = DateTime.Today.Month - 1;
            ComboBoxMonth.Enabled = true;
            NumericUpDownYear.Value = (decimal)DateTime.Today.Year;
            NumericUpDownYear.Enabled = true;
            this.DataGridViewTimes.ClearSelection();
            this.DataGridViewTimes.RowStateChanged -= new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.DataGridViewTimes_RowStateChanged);
            DataGridViewTimes.DataSource = null;
            clockInTimePicker.Enabled = false;
            clockOutTimePicker.Enabled = false;
            datePicker.Enabled = false;
            ButtonLoad.Enabled = true;
            ButtonSave.Enabled = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            // vars
            List<string> newFile = new List<string>();
            string[] oldFile;

            try
            {
                // go through each time combo
                foreach (TimeCombo time in timeList)
                {
                    // add time to list of strings to write as the new file
                    newFile.Add(time.clockedIn.ToBinary().ToString() + "\t" + time.clockedOut.ToBinary().ToString());
                }

                // add last line of old file if there's only one binary time value (aka. their currently clocked in)
                oldFile = File.ReadAllLines(TextBoxCardID.Text.Trim() + ".txt");
                if (oldFile[oldFile.Length - 1].Split(new char[] { '\t' })[1].Length == 1)
                    newFile.Add(oldFile[oldFile.Length - 1]);

                // write changes to disk
                File.WriteAllLines(TextBoxCardID.Text.Trim() + ".txt", newFile);

                // disable duplicate saving
                ButtonSave.Enabled = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "There was an error while trying to save your changes.\n\n" + err.Message, "Time Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormEditPast_FormClosing(object sender, FormClosingEventArgs e)
        {
            // make sure nothing needs to be saved
            if (ButtonSave.Enabled)
            {
                // switch on user choice
                switch (MessageBox.Show(this, "There are unsaved changes. Would you like to save them before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
                {
                    case DialogResult.Yes: ButtonSave_Click(sender, e);
                        break;
                    case DialogResult.Cancel: e.Cancel = true;
                        break;
                }
            }
        }
    }

    class TimeCombo
    {
        public DateTime clockedIn { get; set; }
        public DateTime clockedOut { get; set; }

        public TimeCombo()
        {
            clockedIn = new DateTime();
            clockedOut = new DateTime();
        }

        public TimeCombo(DateTime timeIn, DateTime timeOut)
        {
            clockedIn = timeIn;
            clockedOut = timeOut;
        }
    }
}