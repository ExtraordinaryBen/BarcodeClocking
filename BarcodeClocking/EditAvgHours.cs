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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BarcodeClocking
{
    public partial class EditAvgHours : Form
    {
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;

        public EditAvgHours()
        {
            InitializeComponent();

            this.DisableUI();
        }

        private void DisableUI()
        {
            this.SaveButton.Enabled = false;
            this.DeleteButton.Enabled = false;
            this.ClearButton.Enabled = false;
            this.ClockInTimePicker.Enabled = false;
            this.ClockOutTimePicker.Enabled = false;
            this.DayOfWeekComboBox.Enabled = false;

        }

        private void EnableUI()
        {
            this.SaveButton.Enabled = true;
            this.DeleteButton.Enabled = true;
            this.ClearButton.Enabled = true;
            this.ClockInTimePicker.Enabled = true;
            this.ClockOutTimePicker.Enabled = true;
            this.DayOfWeekComboBox.Enabled = true;

        }

        private void AvgHoursGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (this.AvgHoursGridView.SelectedRows.Count > 0)
            {
                DateTime clockIn;
                DateTime clockOut;
                DateTime.TryParseExact(e.Row.Cells[2].Value.ToString(), "HH:mm", null, DateTimeStyles.None, out clockIn);
                DateTime.TryParseExact(e.Row.Cells[3].Value.ToString(), "HH:mm", null, DateTimeStyles.None, out clockOut);

                ClockInTimePicker.Value = clockIn;
                ClockOutTimePicker.Value = clockOut;

                this.DayOfWeekComboBox.SelectedIndex = int.Parse(e.Row.Cells[1].Value.ToString()) - 1;

                // enable UI
                this.EnableUI();
                this.SaveButton.Text = "Save";

            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if(TextBoxCardID.Text != "")
            {


                try
                {
                    if (Helper.EmployeeExists(TextBoxCardID.Text, sql))
                    {
                        //Disable UIs
                        this.TextBoxCardID.Enabled = false;
                        this.LoadButton.Enabled = false;


                        dt = sql.GetDataTable("select id, dayOfWeek as Day, clockIn, clockOut from avgHours where employeeId=" + TextBoxCardID.Text + " order by dayOfWeek asc;");

                        if (dt.Rows.Count > 0)
                        {
                            this.AvgHoursGridView.DataSource = dt;

                            this.AvgHoursGridView.ClearSelection();

                            //Hide id column, used to determine which entry to update/remove 
                            this.AvgHoursGridView.Columns[0].Visible = false;



                            foreach (DataGridViewColumn column in AvgHoursGridView.Columns)
                            {
                                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                            }



                            this.AvgHoursGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AvgHoursGridView_RowStateChanged);

                        }
                        else
                        {
                            MessageBox.Show("No entries were found for this ID,\n use the fields below to add one.", "No entries found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.SetAddButton();
                    }
                    else
                        throw new ArgumentException("The ID you entered does not exist, please make sure ID was entered correctly.");


                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "An Error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }


        // Changes how cells are displayed depending on their columns and values.
        private void AvgHoursGridView_CellFormatting(object sender,
            System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            // Set the background to red for negative values in the Balance column.
            if (AvgHoursGridView.Columns[e.ColumnIndex].Name.Equals("clockIn")
                || AvgHoursGridView.Columns[e.ColumnIndex].Name.Equals("clockOut") )
            {
                DateTime time;

                DateTime.TryParseExact(e.Value.ToString(), "HH:mm", null, DateTimeStyles.None, out time);

                e.Value = time.ToString("h:mm tt");

            }
            else if(AvgHoursGridView.Columns[e.ColumnIndex].Name.Equals("Day"))
            {
                switch (e.Value.ToString())
                {
                    case "1":
                        e.Value = "Mon";
                        break;
                    case "2":
                        e.Value = "Tue";
                        break;
                    case "3":
                        e.Value = "Wed";
                        break;
                    case "4":
                        e.Value = "Thu";
                        break;
                    case "5":
                        e.Value = "Fri";
                        break;
                    case "6":
                        e.Value = "Sat";
                        break;

                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                string dayOfWeek = (DayOfWeekComboBox.SelectedIndex + 1).ToString();
                string clockIn = ClockInTimePicker.Value.ToString("HH:mm");
                string clockOut = ClockOutTimePicker.Value.ToString("HH:mm");

                Dictionary<String, String> data = new Dictionary<String, String>();
                data.Add("dayOfWeek", dayOfWeek);
                data.Add("clockIn", clockIn);
                data.Add("clockOut", clockOut);

                if (this.SaveButton.Text == "Save" && AvgHoursGridView.SelectedRows.Count > 0)
                {
                    string entryId = AvgHoursGridView.SelectedRows[0].Cells[0].Value.ToString();
                    if (sql.Update("avgHours", data, String.Format("avgHours.id = {0}", entryId)))
                    {
                        AvgHoursGridView.SelectedRows[0].Cells[1].Value = dayOfWeek;
                        AvgHoursGridView.SelectedRows[0].Cells[2].Value = clockIn;
                        AvgHoursGridView.SelectedRows[0].Cells[3].Value = clockOut;

                        this.SetAddButton();
                    }
                }
                else if(this.SaveButton.Text == "Add" && AvgHoursGridView.SelectedRows.Count == 0)
                {
                    data.Add("employeeID", this.TextBoxCardID.Text.Trim());
                    if(sql.Insert("avgHours", data))
                    {
                        DataTable dt = AvgHoursGridView.DataSource as DataTable;

                        DataRow dr = dt.NewRow();
                        dr[0] = sql.ExecuteScalar("select seq from sqlite_sequence where name='avgHours';");
                        dr[1] = dayOfWeek;
                        dr[2] = clockIn;
                        dr[3] = clockOut;

                        this.AvgHoursGridView.RowStateChanged -= new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AvgHoursGridView_RowStateChanged);

                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                        AvgHoursGridView.ClearSelection();

                        this.AvgHoursGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AvgHoursGridView_RowStateChanged);

                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "There was an error while trying to save the entry.\n\n" + err.Message, "Save Avg Hours Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string toDeleteId = this.AvgHoursGridView.SelectedRows[0].Cells[0].Value.ToString();
                int rowId = this.AvgHoursGridView.SelectedRows[0].Index;

                if(sql.Delete("avgHours", "id=" + toDeleteId))
                {
                    this.DisableUI();
                    this.AvgHoursGridView.RowStateChanged -= new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AvgHoursGridView_RowStateChanged);
                    this.AvgHoursGridView.Rows.RemoveAt(rowId);
                    this.AvgHoursGridView.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.AvgHoursGridView_RowStateChanged);
                    this.SetAddButton();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, "There was an error while trying to delete the entry.\n\n" + err.Message, "Delete Avg Hours Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.SetAddButton();
        }

        private void SetAddButton()
        {
            this.AvgHoursGridView.ClearSelection();
            this.DeleteButton.Enabled = false;
            this.ClearButton.Enabled = false;
            this.ClockInTimePicker.Enabled = true;
            this.ClockOutTimePicker.Enabled = true;
            this.DayOfWeekComboBox.Enabled = true;
            this.SaveButton.Enabled = true;
            this.SaveButton.Text = "Add";
        }

    }
}
