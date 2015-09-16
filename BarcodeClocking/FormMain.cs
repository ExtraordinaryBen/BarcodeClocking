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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace BarcodeClocking
{
    public partial class FormMain : Form
    {
        #region Declarations

        // vars
        private char[] invalidChars;
        private string input;
        private SQLiteDatabase sql = new SQLiteDatabase();
        DataTable dt;

        #endregion

        #region General Form Stuff

        public FormMain()
        {
            // vars
            bool goAgain;

            // get list of invalid chars for system
            invalidChars = Path.GetInvalidFileNameChars();

            // check for existence of required iText DLL
            if (!File.Exists("itextsharp.dll"))
            {
                do
                {
                    // (re)set vars
                    goAgain = false;

                    try
                    {
                        // extract file
                        File.WriteAllBytes("itextsharp.dll", Properties.Resources.itextsharp);
                    }
                    catch (Exception err)
                    {
                        // ask user what they want to do
                        switch (MessageBox.Show(this, "There was an error while trying to extract the required file for generating the time sheet.\n\n" + err.Message + "\n\nAbort will close this application. Ignore will temporarily disable the option to make the time sheets.", "Extract File Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error))
                        {
                            // exit the app
                            case DialogResult.Abort: this.Close();
                                break;
                            // try extracting the file again
                            case DialogResult.Retry: goAgain = true;
                                break;
                            // disable option to generate time sheets and add the reason why
                            case DialogResult.Ignore: ToolStripMenuItemGenerate.Enabled = false;
                                ToolStripMenuItemGenerate.ToolTipText = "The required file isn't available.";
                                break;
                        }
                    }
                } while (goAgain);
            }

            // create gui
            InitializeComponent();

            //Start the clock
            //System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();


            if (sql.GetDataTable("select employeeID from employees;").Rows.Count == 0)
            {
                var result = MessageBox.Show(this, "It looks like there aren't any registered cards yet. You can add a card by pressing Alt + N on the keyboard, or by clicking on the 'Add new card' option from the 'Manage Cards' menu."
                    + "\n\n Would you like to check to attemp importing an existing database?", "No Registered Cards", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    ImportCardList cardList = new ImportCardList("cardList");
                }
            }
            else
                autoClockOut();

        }


        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            // try to keep this form activated to capture input
            Thread.Sleep(500);
            this.Activate();
        }

        private void TimerInputTimeout_Tick(object sender, EventArgs e)
        {
            // reset input storage
            LabelInput.Text = "input: ";
            input = "";

            // reset status indicator
            ResetStatus();

            // disable timer
            TimerInputTimeout.Enabled = false;
        }

        private void StoreInput(char inputChar)
        {
            // make sure no dialogs from this app are open
            if (!(this.Visible && !this.CanFocus))
            {
                // make sure this is thread-safe
                if (LabelInput.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate() { StoreInput(inputChar); }));
                else
                {
                    // work with backspace
                    if (inputChar.Equals('\b'))
                    {
                        // make sure there's at least one char to remove
                        if ( (input != null) && input.Length > 0)
                        {
                            LabelInput.Text = LabelInput.Text.Substring(0, LabelInput.Text.Length - 1);
                            input = input.Substring(0, input.Length - 1);
                        }

                        // reset timer
                        TimerInputTimeout.Stop();
                        TimerInputTimeout.Interval = 5000;
                        TimerInputTimeout.Start();

                        // stop processing input
                        return;
                    }
                    // replace invalid chars
                    else if (invalidChars.Contains(inputChar))
                        inputChar = '_';

                    // store input
                    LabelInput.Text = LabelInput.Text + inputChar.ToString();
                    input = input + inputChar.ToString();

                    // reset timer
                    TimerInputTimeout.Stop();
                    TimerInputTimeout.Interval = 5000;
                    TimerInputTimeout.Start();
                }
            }
        }

        private void ResetStatus()
        {
            LabelStatus.Text = "Waiting for card scan . . .";
        }

        #endregion

        #region Time Calculation Stuff

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            // vars
            int timeStampId;
            string firstName;

            // check for user/scanner pressing enter
            if (e.KeyChar.Equals('\r') || e.KeyChar.Equals('\n'))
            {
                // remove leading and trailing spaces
                input = input.Trim();

                // check for existence of card
                if (Helper.EmployeeExists(input, sql))
                {
                    dt= sql.GetDataTable("select * from employees where employeeID=" + input + ";");
                    timeStampId = int.Parse(dt.Rows[0].ItemArray[6].ToString());
                    firstName = dt.Rows[0].ItemArray[1].ToString();

                    // check for clock-in or -out
                    if ( timeStampId > 0 )
                    {
                        try
                        {
                            

                            // clock out
                            Dictionary<String, String> data = new Dictionary<String, String>();
                            data.Add("clockOut", DateTime.Now.ToString(StringFormats.sqlTimeFormat));

                            sql.Update("timeStamps", data, String.Format("timeStamps.id = {0}", timeStampId));


                            sql.ExecuteNonQuery("update employees set currentClockInId = 0 where employeeId="+input+";");
                            
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(this, "There was an error while trying to clock you out.\n\n" + err.Message, "Clock Out Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // calculate time logged
                        dt = sql.GetDataTable("select strftime('%s', clockOut) - strftime('%s', clockIn) from timeStamps where id="+timeStampId+";");
                        TimeSpan diff = TimeSpan.FromSeconds(long.Parse(dt.Rows[0].ItemArray[0].ToString()));

                        // show confirmation
                        LabelStatus.Text = "Goodbye " + firstName + ".\nYou logged " + GenerateClockedTime(diff) + ".";
                        TimerInputTimeout.Interval = 3000;
                        TimerInputTimeout.Enabled = true;
                    }
                    else
                    {
                        // clock in
                        try
                        {
                            Dictionary<String, String> data = new Dictionary<String, String>();
                            data.Add("employeeID", input);
                            data.Add("clockIn", DateTime.Now.ToString(StringFormats.sqlTimeFormat));


                            sql.Insert("timeStamps", data);
                            dt = sql.GetDataTable("select seq from sqlite_sequence where name='timeStamps';");
                            
                            data.Clear();
                            data.Add("currentClockInId", dt.Rows[0].ItemArray[0].ToString());
                            
                            sql.Update("employees", data, String.Format("employees.employeeId = {0}", input));
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(this, "There was an error while trying to clock you in.\n\n" + err.Message, "Clock In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // show confirmation
                        LabelStatus.Text = "Hello " + firstName + "!\nYou're now clocked in.";
                        TimerInputTimeout.Interval = 2500;
                        TimerInputTimeout.Enabled = true;
                    }

                }
                else
                {
                    // notify user of unrecognized card
                    LabelStatus.Text = "Unrecognized card!";
                    TimerInputTimeout.Interval = 2500;
                    TimerInputTimeout.Enabled = true;
                }

                // reset input storage
                LabelInput.Text = "input: ";
                input = "";
            }
            else
                // add the input
                StoreInput(e.KeyChar);
        }

        private string GenerateClockedTime(TimeSpan diff)
        {
            // vars
            bool days = false;
            bool hours = false;
            bool minutes = false;
            bool seconds = false;
            string loggedTime = "";

            // figure out what to display
            if (diff.Days > 0)
                days = true;
            if (diff.Hours > 0)
                hours = true;
            if (diff.Minutes > 0)
                minutes = true;
            if (diff.Seconds > 0)
                seconds = true;

            // create logged time text
            if (days)
            {
                // add days value
                if (diff.Days > 1)
                    loggedTime = diff.Days.ToString() + " days";
                // add day
                else
                    loggedTime = diff.Days.ToString() + " day";

                // add comma if there's another value
                if (hours || minutes || seconds)
                    loggedTime = loggedTime + ", ";
            }
            if (hours)
            {
                // add "and" if there were days, and no minutes or seconds
                if (days && !(minutes || seconds))
                    loggedTime = loggedTime + "and ";

                // add hours value
                if (diff.Hours > 1)
                    loggedTime = loggedTime + diff.Hours.ToString() + " hours";
                // add hour
                else
                    loggedTime = loggedTime + diff.Hours.ToString() + " hour";

                // add comma if there's another value
                if (minutes || seconds)
                    loggedTime = loggedTime + ", ";
            }
            if (minutes)
            {
                // add "and" if there were days or hours, and no seconds
                if ((days || hours) && !seconds)
                    loggedTime = loggedTime + "and ";

                // add minutes value
                if (diff.Minutes > 1)
                    loggedTime = loggedTime + diff.Minutes.ToString() + " minutes";
                // add minute
                else
                    loggedTime = loggedTime + diff.Minutes.ToString() + " minute";

                // add comma if there's a seconds value
                if (seconds)
                    loggedTime = loggedTime + ", ";
            }
            if (seconds)
            {
                // add "and" if there was a previous value
                if (days || hours || minutes)
                    loggedTime = loggedTime + "and ";

                // add seconds value
                if (diff.Seconds > 1)
                    loggedTime = loggedTime + diff.Seconds.ToString() + " seconds";
                // add second
                else
                    loggedTime = loggedTime + diff.Seconds.ToString() + " second";
            }

            // just in case a user managed to get no time logged
            if (!(days || hours || minutes || seconds))
                loggedTime = "no time";

            // return string
            return loggedTime;
        }

        private long Base36Decode(string inputString)
        { // this method is based on the code found at https://en.wikipedia.org/wiki/Base_36#C.23_implementation (on 12/16/14)
            // vars
            string Clist = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            long result = 0;
            int pow = 0;

            // convert input string to upper-case
            inputString = inputString.ToUpper();

            // go through each char in input string
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                // find position value
                int pos = Clist.IndexOf(inputString[i]);

                // make sure it's a valid base-36 char
                if (pos > -1)
                    // raise position value to place value
                    result += pos * (long)Math.Pow(Clist.Length, pow);
                else
                    // report invalid value
                    return -1;

                // procede to the next place value
                pow++;
            }

            // return the equivalent base-10 number
            return result;
        }

        #endregion

        #region ToolStrip Menu Items

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            // close this app
            this.Close();
        }

        private void ToolStripMenuItemNewCard_Click(object sender, EventArgs e)
        {
            // change status
            LabelStatus.Text = "Waiting for new card to be added . . .";

            // show form
            FormAddCard addCardForm = new FormAddCard();
            addCardForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void ToolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            // change status
            LabelStatus.Text = "Waiting for card editing to finish . . .";

            // show form
            FormEditCard editCardForm = new FormEditCard();
            editCardForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void ToolStripMenuItemRemoveCard_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for card removal to complete . . .";

            // show form
            FormRemoveCard removeCardForm = new FormRemoveCard();
            removeCardForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void TimeSheetToolStripMenuItemGenerate_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for time sheet to be generated . . .";

            // show form
            FormGenerate generateForm = new FormGenerate();
            generateForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for About window to close . . .";

            // show about box
            FormAboutBox aboutBox = new FormAboutBox();
            aboutBox.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void ToolStripMenuItemEditPast_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for past time editor to close . . .";

            // show form
            FormEditPast editForm = new FormEditPast();
            editForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        private void ToolStripMenuItemAddTime_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for additional time to be added . . .";

            // show form
            FormAddTime addForm = new FormAddTime();
            addForm.ShowDialog();

            // reset status
            ResetStatus();
        }

        #endregion

        //http://stackoverflow.com/questions/11952075/timer-refresh-functionality-for-text-box

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            dateBox.Text = DateTime.Now.ToString("D");

            if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
                autoClockOut();
        }

        private void autoClockOut()
        {
            DataTable toClockOut = sql.GetDataTable("select timeStamps.employeeID, " 
            + "timeStamps.id as timeStampId, timeStamps.clockIn, avgHours.clockOut from avgHours "
            + "join timeStamps join employees where avgHours.employeeID = timeStamps.employeeID " 
            + "and time(timeStamps.clockIn) <= time(avgHours.clockIn, '+15 minutes') "
            + "and time(timeStamps.clockIn) >= time(avgHours.clockIn, '-15 minutes') "
            + "and cast(strftime('%w', timeStamps.clockIn) as integer) = avgHours.dayOfWeek "
            + "and timeStamps.id = employees.currentClockInId;");

            if(toClockOut.Rows.Count > 0)
            {
                foreach(DataRow row in toClockOut.Rows)
                {
                    try 
                    {
                        DateTime clockIn = DateTime.Parse(row.ItemArray[2].ToString());
                        string[] clockOutStr = row.ItemArray[3].ToString().Split(':');
                        DateTime clockOut = clockIn.Date + new TimeSpan(int.Parse(clockOutStr[0]), int.Parse(clockOutStr[1]), 0);

                        


                        Dictionary<String, String> data = new Dictionary<String, String>();
                        data.Add("clockOut", clockOut.ToString(StringFormats.sqlTimeFormat));


                        sql.Update("timeStamps", data, "timeStamps.id = " + row.ItemArray[1].ToString() );

                        sql.ExecuteNonQuery("update employees set currentClockInId = 0 where employeeId=" + row.ItemArray[0].ToString() + ";");

                    }
                    catch(Exception err)
                    {
                        File.WriteAllText("AutoClockOutError-"+row.ItemArray[0].ToString()+".txt", "AutoClockOutError: " + err.Message + "\r\n\r\n");
                    }

                }

            }

        }

        private void editAvgHoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // update status
            LabelStatus.Text = "Waiting for Avg. Hours window to close . . .";

            // show about box
            EditAvgHours EditAvgHoursBox = new EditAvgHours();
            EditAvgHoursBox.ShowDialog();

            // reset status
            ResetStatus();
        }

    }

}