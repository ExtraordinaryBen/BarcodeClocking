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
    partial class FormRemoveCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemoveCard));
            this.LabelTip = new System.Windows.Forms.Label();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.LabelCardID = new System.Windows.Forms.Label();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.CheckBoxDelTimeLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LabelTip
            // 
            this.LabelTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTip.Location = new System.Drawing.Point(12, 9);
            this.LabelTip.Name = "LabelTip";
            this.LabelTip.Size = new System.Drawing.Size(358, 37);
            this.LabelTip.TabIndex = 7;
            this.LabelTip.Text = "Scan your card to easily fill in the text box below. Leading and trailing spaces " +
    "are removed.";
            // 
            // TextBoxCardID
            // 
            this.TextBoxCardID.Location = new System.Drawing.Point(130, 49);
            this.TextBoxCardID.Name = "TextBoxCardID";
            this.TextBoxCardID.Size = new System.Drawing.Size(240, 22);
            this.TextBoxCardID.TabIndex = 1;
            this.TextBoxCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Helper.OnKeyPress);
            // 
            // LabelCardID
            // 
            this.LabelCardID.AutoSize = true;
            this.LabelCardID.Location = new System.Drawing.Point(12, 52);
            this.LabelCardID.Name = "LabelCardID";
            this.LabelCardID.Size = new System.Drawing.Size(112, 17);
            this.LabelCardID.TabIndex = 9;
            this.LabelCardID.Text = "Card/Student ID:";
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonRemove.Location = new System.Drawing.Point(0, 125);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(382, 27);
            this.ButtonRemove.TabIndex = 2;
            this.ButtonRemove.Text = "Remove Card";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            this.ButtonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // CheckBoxDelTimeLog
            // 
            this.CheckBoxDelTimeLog.AutoSize = true;
            this.CheckBoxDelTimeLog.Checked = true;
            this.CheckBoxDelTimeLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDelTimeLog.Location = new System.Drawing.Point(12, 77);
            this.CheckBoxDelTimeLog.Name = "CheckBoxDelTimeLog";
            this.CheckBoxDelTimeLog.Size = new System.Drawing.Size(328, 38);
            this.CheckBoxDelTimeLog.TabIndex = 10;
            this.CheckBoxDelTimeLog.Text = "Also delete the respective time log file\r\n(Uncheck if you plan on adding this car" +
    "d again)";
            this.CheckBoxDelTimeLog.UseVisualStyleBackColor = true;
            // 
            // FormRemoveCard
            // 
            this.AcceptButton = this.ButtonRemove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 152);
            this.Controls.Add(this.CheckBoxDelTimeLog);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.LabelCardID);
            this.Controls.Add(this.LabelTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 197);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 197);
            this.Name = "FormRemoveCard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Remove Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTip;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.Label LabelCardID;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.CheckBox CheckBoxDelTimeLog;
    }
}