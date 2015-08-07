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

using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace BarcodeClocking
{
    public partial class FormGenerate : Form
    {
        // vars
        private char[] invalidChars;
        private SQLiteDatabase sql = new SQLiteDatabase();
        private DataTable dt;
        private object[] employee;

        public FormGenerate()
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

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            // vars
            bool found = false;
            double totalHours = 0;
            double[] hours = new double[31];
            string[] timeLog;

            // init hours array
            for (int ii = 0; ii < 31; ii++)
                hours[ii] = 0.0;

            // change gui
            ButtonGenerate.Text = "Generating Time Sheet . . .";
            ButtonGenerate.Enabled = false;
            TextBoxCardID.Enabled = false;
            ComboBoxMonth.Enabled = false;
            NumericUpDownYear.Enabled = false;



            dt = sql.GetDataTable("select * from employees where employeeID=" + TextBoxCardID.Text.Trim() + ";");

            // check if this is the card we're looking for
            if (dt.Rows.Count == 1)
            {
                // mark as found
                found = true;

                employee = dt.Rows[0].ItemArray;

                try
                {
                    // create objects for filling in pdf
                    PdfStamper pdfFormFiller = new PdfStamper(new PdfReader(Properties.Resources.StudentTimeSheet), new FileStream("StudentTimeSheet.pdf", FileMode.Create));
                    AcroFields pdfFormFields = pdfFormFiller.AcroFields;

                    // set position type
                    switch (employee[5].ToString())
                    {
                        case "FWS": pdfFormFields.SetField("Radio Button1", "0");
                            break;
                        case "SWS": pdfFormFields.SetField("Radio Button1", "1");
                            break;
                        case "MST": pdfFormFields.SetField("Radio Button1", "2");
                            break;
                        case "HED": pdfFormFields.SetField("Radio Button1", "3");
                            break;
                        case "Help": pdfFormFields.SetField("Radio Button1", "4");
                            break;
                        case "Tutor1": pdfFormFields.SetField("Radio Button1", "5");
                            break;
                        case "Tutor2": pdfFormFields.SetField("Radio Button1", "6");
                            break;
                        case "TANF": pdfFormFields.SetField("Radio Button1", "7");
                            break;
                        default: pdfFormFields.SetField("Radio Button1", "Off");
                            break;
                    }

                    //Fill name field if last name has value
                    if (employee[2].ToString().Length > 0)
                    {
                        if ((employee[3].ToString().Length > 0))
                            pdfFormFields.SetField("NAME Last, First, Initial please print", employee[2].ToString()
                                + ", " + employee[1].ToString() + ", " + employee[3].ToString() );
                        else
                            pdfFormFields.SetField("NAME Last, First, Initial please print", employee[2].ToString() 
                                + ", " + employee[1].ToString() );
                    }
                    else
                        MessageBox.Show(this, "It appears you haven't added your last name to your profile. Please add your last name so your TimeSheet will be accepted.", "Last name missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // set student id
                    pdfFormFields.SetField("STUDENT ID", employee[0].ToString() );

                    // set month
                    pdfFormFields.SetField("MONTH", ComboBoxMonth.Text);

                    // set year
                    pdfFormFields.SetField("YEAR", NumericUpDownYear.Value.ToString());

                    try
                    {
                        // get time log
                        dt = sql.GetDataTable("select strftime('%m/%d/%Y %H:%M:%S', clockIn) as clockIn, strftime('%m/%d/%Y %H:%M:%S', clockOut) as clockOut "
                             + "from timeStamps where employeeID=" + TextBoxCardID.Text.Trim()
                             + " and cast(strftime('%m', clockIn) as integer) = " + (int)(ComboBoxMonth.SelectedIndex + 1)
                             + " and cast(strftime('%Y', clockIn) as integer) = " + (int)NumericUpDownYear.Value + ";");


                        // get month beginning and end
                        DateTime monthStart = new DateTime((int)NumericUpDownYear.Value, ComboBoxMonth.SelectedIndex + 1, 1);
                        DateTime monthEnd = monthStart.AddMonths(1);

                        // go through each clock-in/-out entry
                        foreach (DataRow entry in dt.Rows)
                        {
                            // get start time
                            DateTime clockedIn = DateTime.Parse(entry.ItemArray[0].ToString());
                                
                            // watch for an entry that doesn't have a clock-out time yet
                            DateTime clockedOut;
                            if (entry.ItemArray[1].ToString().Length == 0)
                            {
                                MessageBox.Show(this, "It appears you are currently clocked in.\n\n Please make sure to clock out before printing your timesheet\n so that your hours are calcuated correctly.", "You are still clocked in!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                clockedOut = DateTime.Now;
                            }
                            else
                                clockedOut = DateTime.Parse(entry.ItemArray[1].ToString());

                            // make sure some part(s) is/are in the respective month
                            if (
                                // clocked in time is within month and year
                                (clockedIn.Month.Equals(ComboBoxMonth.SelectedIndex + 1) && clockedIn.Year.Equals((int)NumericUpDownYear.Value))
                                // clocked out time is within month and year
                                || (clockedOut.Month.Equals(ComboBoxMonth.SelectedIndex + 1) && clockedOut.Year.Equals((int)NumericUpDownYear.Value))
                                // month and year are between clocked in and out times
                                || (
                                    // clocked in before date
                                    (clockedIn < monthStart)
                                    // clocked out after date
                                    && (clockedOut >= monthEnd)
                                )
                            )
                            {
                                // check for both times existing on the same date
                                if (clockedIn.Date.Equals(clockedOut.Date))
                                {
                                    // figure out the difference and set time for respective day
                                    hours[clockedIn.Day - 1] += (clockedOut - clockedIn).TotalHours;
                                }
                                // figure out time on the respective days between the times
                                else
                                {
                                    // make sure clocked in time is within respective month
                                    if (clockedIn < monthStart)
                                        clockedIn = monthStart;

                                    // make sure clocked out time is within respective month
                                    if (clockedOut >= monthEnd)
                                        clockedOut = monthEnd;

                                    // figure out the difference for the first day
                                    DateTime midNight = new DateTime(clockedIn.Year, clockedIn.Month, clockedIn.Day).AddDays(1.0);
                                    hours[clockedIn.Day - 1] += (midNight - clockedIn).TotalHours;

                                    // add 24 hours for each full day between clocked in and out times
                                    clockedIn = midNight;
                                    while (clockedIn.Day < clockedOut.Day)
                                    {
                                        hours[clockedIn.Day - 1] += 24.0;
                                        clockedIn = clockedIn.AddDays(1.0);
                                    }

                                    // figure out the difference for the last day
                                    hours[clockedIn.Day - 1] += (clockedOut - clockedIn).TotalHours;
                                }
                            }
                        }

                        // set logged time
                        for (int ii = 0; ii < 31; ii++)
                        {
                            // round value to nearest fourth
                            // see http://stackoverflow.com/a/2826278/3404349
                            hours[ii] = Math.Round((hours[ii] * 4.0), MidpointRounding.ToEven) / 4.0;

                            // check for value greater than 0
                            if (hours[ii] > 0.0)
                                // set hours for respective day
                                pdfFormFields.SetField((ii + 1).ToString(), hours[ii].ToString("#.00"));
                        }

                        // set total hours
                        foreach (double hour in hours)
                            totalHours += hour;
                        pdfFormFields.SetField("TOTAL HOURS", totalHours.ToString("#.00"));
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(this, "There was an error while trying to open your time log file. Was someone playing with the database files?\n\n" + err.Message + "\n\n" + err.StackTrace, "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // set hourly rate
                    pdfFormFields.SetField("HOURLY RATE", employee[4].ToString() );

                    // leave the form open to subsequent manual edits
                    pdfFormFiller.FormFlattening = false;

                    // close the pdf
                    pdfFormFiller.Close();

                    try
                    {
                        // open finished pdf file
                        Process openedFile = Process.Start("StudentTimeSheet.pdf");
                            
                        // wait up to 10 minutes for process to close
                        ButtonGenerate.Text = "Waiting for Adobe Reader to close . . .";
                        openedFile.WaitForExit(600000);

                        try
                        {
                            // check for process close or wait time-out
                            if (!openedFile.HasExited)
                            {
                                // notify user the file was not automatically deleted
                                if (MessageBox.Show(this, "Adobe Reader did not close within 10 minutes. It needs to be closed in order to delete the Time Sheet PDF file (recommended for security). Please close Adobe Reader and click OK to delete the file. Click Cancel to skip deleting the file.", "Process Wait-Close Time Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                    // delete file if requested
                                    File.Delete("StudentTimeSheet.pdf");
                            }
                            else
                                // delete file
                                File.Delete("StudentTimeSheet.pdf");
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(this, "There was an error while trying to delete the Student Time Sheet PDF file.\n\n" + err.Message, "Delete File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(this, "There was an error while trying to open the PDF file for your review.\n\n" + err.Message, "Open File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                  
                }
                catch (Exception err)
                {
                    MessageBox.Show(this, "There was an error while trying to create the PDF file.\n\n" + err.Message, "File Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
            // notify user if card wasn't found
            if (!found)
            {
                MessageBox.Show(this, "The card you entered wasn't found. Are you sure you typed it in correctly?", "Card Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // reset gui
            TextBoxCardID.Enabled = true;
            ComboBoxMonth.Enabled = true;
            NumericUpDownYear.Enabled = true;
            ButtonGenerate.Enabled = true;
            ButtonGenerate.Text = "Generate Time Sheet";
            TextBoxCardID.Focus();
            TextBoxCardID.SelectAll();
        }
    }
}