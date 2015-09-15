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

namespace BarcodeClocking
{
    partial class FormEditPast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditPast));
            this.LabelHint = new System.Windows.Forms.Label();
            this.LabelMonth = new System.Windows.Forms.Label();
            this.ComboBoxMonth = new System.Windows.Forms.ComboBox();
            this.DataGridViewTimes = new System.Windows.Forms.DataGridView();
            this.ColumnClockIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClockOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.LabelCardID = new System.Windows.Forms.Label();
            this.NumericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.LabelYear = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.clockInTimePicker = new System.Windows.Forms.DateTimePicker();
            this.clockOutTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.clockInLabel = new System.Windows.Forms.Label();
            this.clockOutLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelHint
            // 
            this.LabelHint.Location = new System.Drawing.Point(9, 7);
            this.LabelHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelHint.Name = "LabelHint";
            this.LabelHint.Size = new System.Drawing.Size(406, 54);
            this.LabelHint.TabIndex = 0;
            this.LabelHint.Text = "Scan your card or enter your Student ID to pull up logged times within the respec" +
    "tive month. ";
            // 
            // LabelMonth
            // 
            this.LabelMonth.AutoSize = true;
            this.LabelMonth.Location = new System.Drawing.Point(9, 89);
            this.LabelMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelMonth.Name = "LabelMonth";
            this.LabelMonth.Size = new System.Drawing.Size(40, 13);
            this.LabelMonth.TabIndex = 5;
            this.LabelMonth.Text = "Month:";
            // 
            // ComboBoxMonth
            // 
            this.ComboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMonth.FormattingEnabled = true;
            this.ComboBoxMonth.ItemHeight = 13;
            this.ComboBoxMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.ComboBoxMonth.Location = new System.Drawing.Point(98, 87);
            this.ComboBoxMonth.Margin = new System.Windows.Forms.Padding(2);
            this.ComboBoxMonth.MaxDropDownItems = 12;
            this.ComboBoxMonth.Name = "ComboBoxMonth";
            this.ComboBoxMonth.Size = new System.Drawing.Size(200, 21);
            this.ComboBoxMonth.TabIndex = 2;
            // 
            // DataGridViewTimes
            // 
            this.DataGridViewTimes.AllowUserToAddRows = false;
            this.DataGridViewTimes.AllowUserToResizeColumns = false;
            this.DataGridViewTimes.AllowUserToResizeRows = false;
            this.DataGridViewTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewTimes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewTimes.Location = new System.Drawing.Point(9, 134);
            this.DataGridViewTimes.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewTimes.MultiSelect = false;
            this.DataGridViewTimes.Name = "DataGridViewTimes";
            this.DataGridViewTimes.ReadOnly = true;
            this.DataGridViewTimes.RowHeadersVisible = false;
            this.DataGridViewTimes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.DataGridViewTimes.RowTemplate.Height = 24;
            this.DataGridViewTimes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewTimes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewTimes.Size = new System.Drawing.Size(406, 155);
            this.DataGridViewTimes.TabIndex = 5;
            // 
            // ColumnClockIn
            // 
            this.ColumnClockIn.Name = "ColumnClockIn";
            // 
            // ColumnClockOut
            // 
            this.ColumnClockOut.Name = "ColumnClockOut";
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(302, 70);
            this.ButtonLoad.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(112, 22);
            this.ButtonLoad.TabIndex = 4;
            this.ButtonLoad.Text = "Load Times";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // TextBoxCardID
            // 
            this.TextBoxCardID.Location = new System.Drawing.Point(98, 64);
            this.TextBoxCardID.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxCardID.Name = "TextBoxCardID";
            this.TextBoxCardID.Size = new System.Drawing.Size(200, 20);
            this.TextBoxCardID.TabIndex = 1;
            // 
            // LabelCardID
            // 
            this.LabelCardID.AutoSize = true;
            this.LabelCardID.Location = new System.Drawing.Point(9, 67);
            this.LabelCardID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelCardID.Name = "LabelCardID";
            this.LabelCardID.Size = new System.Drawing.Size(88, 13);
            this.LabelCardID.TabIndex = 11;
            this.LabelCardID.Text = "Card/Student ID:";
            // 
            // NumericUpDownYear
            // 
            this.NumericUpDownYear.Location = new System.Drawing.Point(98, 111);
            this.NumericUpDownYear.Margin = new System.Windows.Forms.Padding(2);
            this.NumericUpDownYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumericUpDownYear.Minimum = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.NumericUpDownYear.Name = "NumericUpDownYear";
            this.NumericUpDownYear.Size = new System.Drawing.Size(200, 20);
            this.NumericUpDownYear.TabIndex = 3;
            this.NumericUpDownYear.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // LabelYear
            // 
            this.LabelYear.AutoSize = true;
            this.LabelYear.Location = new System.Drawing.Point(9, 113);
            this.LabelYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelYear.Name = "LabelYear";
            this.LabelYear.Size = new System.Drawing.Size(32, 13);
            this.LabelYear.TabIndex = 13;
            this.LabelYear.Text = "Year:";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(344, 400);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(70, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(302, 102);
            this.ButtonReset.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(112, 22);
            this.ButtonReset.TabIndex = 7;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "MM/dd/yy";
            this.datePicker.Enabled = false;
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(315, 313);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(99, 20);
            this.datePicker.TabIndex = 14;
            // 
            // clockInTimePicker
            // 
            this.clockInTimePicker.CustomFormat = "";
            this.clockInTimePicker.Enabled = false;
            this.clockInTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.clockInTimePicker.Location = new System.Drawing.Point(326, 340);
            this.clockInTimePicker.Name = "clockInTimePicker";
            this.clockInTimePicker.ShowUpDown = true;
            this.clockInTimePicker.Size = new System.Drawing.Size(87, 20);
            this.clockInTimePicker.TabIndex = 15;
            // 
            // clockOutTimePicker
            // 
            this.clockOutTimePicker.Enabled = false;
            this.clockOutTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.clockOutTimePicker.Location = new System.Drawing.Point(326, 369);
            this.clockOutTimePicker.Name = "clockOutTimePicker";
            this.clockOutTimePicker.ShowUpDown = true;
            this.clockOutTimePicker.Size = new System.Drawing.Size(87, 20);
            this.clockOutTimePicker.TabIndex = 16;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(270, 316);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 13);
            this.dateLabel.TabIndex = 17;
            this.dateLabel.Text = "Date:";
            // 
            // clockInLabel
            // 
            this.clockInLabel.AutoSize = true;
            this.clockInLabel.Location = new System.Drawing.Point(269, 343);
            this.clockInLabel.Name = "clockInLabel";
            this.clockInLabel.Size = new System.Drawing.Size(49, 13);
            this.clockInLabel.TabIndex = 18;
            this.clockInLabel.Text = "Clock In:";
            // 
            // clockOutLabel
            // 
            this.clockOutLabel.AutoSize = true;
            this.clockOutLabel.Location = new System.Drawing.Point(268, 372);
            this.clockOutLabel.Name = "clockOutLabel";
            this.clockOutLabel.Size = new System.Drawing.Size(57, 13);
            this.clockOutLabel.TabIndex = 19;
            this.clockOutLabel.Text = "Clock Out:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(271, 400);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(68, 23);
            this.DeleteButton.TabIndex = 20;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // FormEditPast
            // 
            this.AcceptButton = this.ButtonLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 432);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.clockOutLabel);
            this.Controls.Add(this.clockInLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.clockOutTimePicker);
            this.Controls.Add(this.clockInTimePicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelYear);
            this.Controls.Add(this.NumericUpDownYear);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.LabelCardID);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.DataGridViewTimes);
            this.Controls.Add(this.LabelMonth);
            this.Controls.Add(this.ComboBoxMonth);
            this.Controls.Add(this.LabelHint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(441, 470);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(441, 470);
            this.Name = "FormEditPast";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Past Time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditPast_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelHint;
        private System.Windows.Forms.Label LabelMonth;
        private System.Windows.Forms.ComboBox ComboBoxMonth;
        private System.Windows.Forms.DataGridView DataGridViewTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClockIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClockOut;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.Label LabelCardID;
        private System.Windows.Forms.NumericUpDown NumericUpDownYear;
        private System.Windows.Forms.Label LabelYear;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker clockInTimePicker;
        private System.Windows.Forms.DateTimePicker clockOutTimePicker;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label clockInLabel;
        private System.Windows.Forms.Label clockOutLabel;
        private System.Windows.Forms.Button DeleteButton;
    }
}