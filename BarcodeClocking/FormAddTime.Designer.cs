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
    partial class FormAddTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddTime));
            this.DateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.LabelTip = new System.Windows.Forms.Label();
            this.LabelIn = new System.Windows.Forms.Label();
            this.LabelOut = new System.Windows.Forms.Label();
            this.DateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.LabelID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DateTimePickerIn
            // 
            this.DateTimePickerIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePickerIn.CustomFormat = "dddd, MMMM d, yyyy h:mm:ss tt";
            this.DateTimePickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerIn.Location = new System.Drawing.Point(95, 67);
            this.DateTimePickerIn.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerIn.Name = "DateTimePickerIn";
            this.DateTimePickerIn.Size = new System.Drawing.Size(269, 20);
            this.DateTimePickerIn.TabIndex = 2;
            this.DateTimePickerIn.ValueChanged += new System.EventHandler(this.DateTimePickerIn_ValueChanged);
            // 
            // LabelTip
            // 
            this.LabelTip.Location = new System.Drawing.Point(9, 7);
            this.LabelTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTip.Name = "LabelTip";
            this.LabelTip.Size = new System.Drawing.Size(355, 33);
            this.LabelTip.TabIndex = 2;
            this.LabelTip.Text = "Scan your card or enter your Student ID, then set the clock-in and clock-out time" +
    "s. Click the \"Add Time\" button to log the time.";
            // 
            // LabelIn
            // 
            this.LabelIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelIn.AutoSize = true;
            this.LabelIn.Location = new System.Drawing.Point(22, 67);
            this.LabelIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelIn.Name = "LabelIn";
            this.LabelIn.Size = new System.Drawing.Size(75, 13);
            this.LabelIn.TabIndex = 3;
            this.LabelIn.Text = "Clock-In Time:";
            // 
            // LabelOut
            // 
            this.LabelOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelOut.AutoSize = true;
            this.LabelOut.Location = new System.Drawing.Point(168, 91);
            this.LabelOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelOut.Name = "LabelOut";
            this.LabelOut.Size = new System.Drawing.Size(83, 13);
            this.LabelOut.TabIndex = 5;
            this.LabelOut.Text = "Clock-Out Time:";
            // 
            // DateTimePickerOut
            // 
            this.DateTimePickerOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePickerOut.CustomFormat = "h:mm:ss tt";
            this.DateTimePickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerOut.Location = new System.Drawing.Point(255, 91);
            this.DateTimePickerOut.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerOut.Name = "DateTimePickerOut";
            this.DateTimePickerOut.ShowUpDown = true;
            this.DateTimePickerOut.Size = new System.Drawing.Size(110, 20);
            this.DateTimePickerOut.TabIndex = 3;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdd.Location = new System.Drawing.Point(255, 141);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(110, 22);
            this.ButtonAdd.TabIndex = 4;
            this.ButtonAdd.Text = "Add Time && Close";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // TextBoxID
            // 
            this.TextBoxCardID.AcceptsReturn = true;
            this.TextBoxCardID.Location = new System.Drawing.Point(95, 43);
            this.TextBoxCardID.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxCardID.Name = "TextBoxID";
            this.TextBoxCardID.Size = new System.Drawing.Size(270, 20);
            this.TextBoxCardID.TabIndex = 1;
            this.TextBoxCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxID_KeyDown);
            this.TextBoxCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Helper.OnKeyPress);
            // 
            // LabelID
            // 
            this.LabelID.AutoSize = true;
            this.LabelID.Location = new System.Drawing.Point(9, 43);
            this.LabelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelID.Name = "LabelID";
            this.LabelID.Size = new System.Drawing.Size(88, 13);
            this.LabelID.TabIndex = 8;
            this.LabelID.Text = "Card/Student ID:";
            // 
            // FormAddTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 169);
            this.Controls.Add(this.LabelID);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.LabelOut);
            this.Controls.Add(this.DateTimePickerOut);
            this.Controls.Add(this.LabelIn);
            this.Controls.Add(this.LabelTip);
            this.Controls.Add(this.DateTimePickerIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddTime";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormAddTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateTimePickerIn;
        private System.Windows.Forms.Label LabelTip;
        private System.Windows.Forms.Label LabelIn;
        private System.Windows.Forms.Label LabelOut;
        private System.Windows.Forms.DateTimePicker DateTimePickerOut;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.Label LabelID;
    }
}