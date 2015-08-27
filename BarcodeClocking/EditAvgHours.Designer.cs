namespace BarcodeClocking
{
    partial class EditAvgHours
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
            this.AvgHoursGridView = new System.Windows.Forms.DataGridView();
            this.DayOfWeekComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClockInTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ClockOutTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DescLabel = new System.Windows.Forms.Label();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.IdLabel = new System.Windows.Forms.Label();
            this.ClockInLabel = new System.Windows.Forms.Label();
            this.ClockOutLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AvgHoursGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AvgHoursGridView
            // 
            this.AvgHoursGridView.AllowUserToAddRows = false;
            this.AvgHoursGridView.AllowUserToResizeColumns = false;
            this.AvgHoursGridView.AllowUserToResizeRows = false;
            this.AvgHoursGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AvgHoursGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AvgHoursGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AvgHoursGridView.Location = new System.Drawing.Point(12, 102);
            this.AvgHoursGridView.MultiSelect = false;
            this.AvgHoursGridView.Name = "AvgHoursGridView";
            this.AvgHoursGridView.ReadOnly = true;
            this.AvgHoursGridView.RowHeadersVisible = false;
            this.AvgHoursGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.AvgHoursGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvgHoursGridView.Size = new System.Drawing.Size(349, 150);
            this.AvgHoursGridView.TabIndex = 3;
            this.AvgHoursGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AvgHoursGridView_CellFormatting);
            // 
            // DayOfWeekComboBox
            // 
            this.DayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayOfWeekComboBox.FormattingEnabled = true;
            this.DayOfWeekComboBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DayOfWeekComboBox.Items.AddRange(new object[] {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri",
            "Sat"});
            this.DayOfWeekComboBox.Location = new System.Drawing.Point(181, 258);
            this.DayOfWeekComboBox.Name = "DayOfWeekComboBox";
            this.DayOfWeekComboBox.Size = new System.Drawing.Size(84, 21);
            this.DayOfWeekComboBox.TabIndex = 2;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(205, 340);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(286, 311);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(286, 340);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClockInTimePicker
            // 
            this.ClockInTimePicker.CustomFormat = "h:mm tt";
            this.ClockInTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ClockInTimePicker.Location = new System.Drawing.Point(286, 258);
            this.ClockInTimePicker.Name = "ClockInTimePicker";
            this.ClockInTimePicker.ShowUpDown = true;
            this.ClockInTimePicker.Size = new System.Drawing.Size(74, 20);
            this.ClockInTimePicker.TabIndex = 5;
            // 
            // ClockOutTimePicker
            // 
            this.ClockOutTimePicker.CustomFormat = "h:mm tt";
            this.ClockOutTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ClockOutTimePicker.Location = new System.Drawing.Point(286, 285);
            this.ClockOutTimePicker.Name = "ClockOutTimePicker";
            this.ClockOutTimePicker.ShowUpDown = true;
            this.ClockOutTimePicker.Size = new System.Drawing.Size(75, 20);
            this.ClockOutTimePicker.TabIndex = 6;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Location = new System.Drawing.Point(6, 11);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(362, 39);
            this.DescLabel.TabIndex = 7;
            this.DescLabel.Text = "\"Average Hours\" are used to determine when you should have clocked out\r\n if you f" +
    "orgot to,or automatically fill in future dates when generating \r\ntime sheets.";
            // 
            // TextBoxCardID
            // 
            this.TextBoxCardID.Location = new System.Drawing.Point(101, 76);
            this.TextBoxCardID.Name = "TextBoxCardID";
            this.TextBoxCardID.Size = new System.Drawing.Size(179, 20);
            this.TextBoxCardID.TabIndex = 0;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(288, 74);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(34, 79);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(61, 13);
            this.IdLabel.TabIndex = 10;
            this.IdLabel.Text = "Student ID:";
            // 
            // ClockInLabel
            // 
            this.ClockInLabel.AutoSize = true;
            this.ClockInLabel.Location = new System.Drawing.Point(126, 261);
            this.ClockInLabel.Name = "ClockInLabel";
            this.ClockInLabel.Size = new System.Drawing.Size(49, 13);
            this.ClockInLabel.TabIndex = 11;
            this.ClockInLabel.Text = "Clock In:";
            // 
            // ClockOutLabel
            // 
            this.ClockOutLabel.AutoSize = true;
            this.ClockOutLabel.Location = new System.Drawing.Point(223, 288);
            this.ClockOutLabel.Name = "ClockOutLabel";
            this.ClockOutLabel.Size = new System.Drawing.Size(57, 13);
            this.ClockOutLabel.TabIndex = 12;
            this.ClockOutLabel.Text = "Clock Out:";
            // 
            // EditAvgHours
            // 
            this.AcceptButton = this.LoadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 372);
            this.Controls.Add(this.ClockOutLabel);
            this.Controls.Add(this.ClockInLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.ClockOutTimePicker);
            this.Controls.Add(this.ClockInTimePicker);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.DayOfWeekComboBox);
            this.Controls.Add(this.AvgHoursGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAvgHours";
            this.Text = "Edit Avg Hours";
            ((System.ComponentModel.ISupportInitialize)(this.AvgHoursGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AvgHoursGridView;
        private System.Windows.Forms.ComboBox DayOfWeekComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker ClockInTimePicker;
        private System.Windows.Forms.DateTimePicker ClockOutTimePicker;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label ClockInLabel;
        private System.Windows.Forms.Label ClockOutLabel;
    }
}