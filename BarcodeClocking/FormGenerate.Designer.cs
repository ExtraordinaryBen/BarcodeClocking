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
    partial class FormGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerate));
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCardID = new System.Windows.Forms.Label();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.ComboBoxMonth = new System.Windows.Forms.ComboBox();
            this.LabelMonth = new System.Windows.Forms.Label();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.NumericUpDownYear = new System.Windows.Forms.NumericUpDown();
            this.LabelYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan your card or type your Student ID and press enter to generate you Time Sheet" +
    ".";
            // 
            // LabelCardID
            // 
            this.LabelCardID.AutoSize = true;
            this.LabelCardID.Location = new System.Drawing.Point(12, 55);
            this.LabelCardID.Name = "LabelCardID";
            this.LabelCardID.Size = new System.Drawing.Size(112, 17);
            this.LabelCardID.TabIndex = 1;
            this.LabelCardID.Text = "Card/Student ID:";
            // 
            // TextBoxCardID
            // 
            this.TextBoxCardID.Location = new System.Drawing.Point(130, 52);
            this.TextBoxCardID.Name = "TextBoxCardID";
            this.TextBoxCardID.Size = new System.Drawing.Size(240, 22);
            this.TextBoxCardID.TabIndex = 1;
            this.TextBoxCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Helper.OnKeyPress);
            // 
            // ComboBoxMonth
            // 
            this.ComboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMonth.FormattingEnabled = true;
            this.ComboBoxMonth.ItemHeight = 16;
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
            this.ComboBoxMonth.Location = new System.Drawing.Point(130, 80);
            this.ComboBoxMonth.MaxDropDownItems = 12;
            this.ComboBoxMonth.Name = "ComboBoxMonth";
            this.ComboBoxMonth.Size = new System.Drawing.Size(240, 24);
            this.ComboBoxMonth.TabIndex = 2;
            // 
            // LabelMonth
            // 
            this.LabelMonth.AutoSize = true;
            this.LabelMonth.Location = new System.Drawing.Point(12, 83);
            this.LabelMonth.Name = "LabelMonth";
            this.LabelMonth.Size = new System.Drawing.Size(51, 17);
            this.LabelMonth.TabIndex = 3;
            this.LabelMonth.Text = "Month:";
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonGenerate.Location = new System.Drawing.Point(0, 138);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(382, 27);
            this.ButtonGenerate.TabIndex = 4;
            this.ButtonGenerate.Text = "Generate Time Sheet";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // NumericUpDownYear
            // 
            this.NumericUpDownYear.Location = new System.Drawing.Point(130, 110);
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
            this.NumericUpDownYear.Size = new System.Drawing.Size(240, 22);
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
            this.LabelYear.Location = new System.Drawing.Point(12, 112);
            this.LabelYear.Name = "LabelYear";
            this.LabelYear.Size = new System.Drawing.Size(42, 17);
            this.LabelYear.TabIndex = 5;
            this.LabelYear.Text = "Year:";
            // 
            // FormGenerate
            // 
            this.AcceptButton = this.ButtonGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 165);
            this.Controls.Add(this.LabelYear);
            this.Controls.Add(this.NumericUpDownYear);
            this.Controls.Add(this.ButtonGenerate);
            this.Controls.Add(this.LabelMonth);
            this.Controls.Add(this.ComboBoxMonth);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.LabelCardID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 189);
            this.Name = "FormGenerate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Generate Time Sheet";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCardID;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.ComboBox ComboBoxMonth;
        private System.Windows.Forms.Label LabelMonth;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.NumericUpDown NumericUpDownYear;
        private System.Windows.Forms.Label LabelYear;
    }
}