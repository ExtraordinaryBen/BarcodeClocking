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
    partial class FormEditCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditCard));
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.LabelCardID = new System.Windows.Forms.Label();
            this.TextBoxCardID = new System.Windows.Forms.TextBox();
            this.LabelTip = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelSeparator = new System.Windows.Forms.Label();
            this.LabelMI = new System.Windows.Forms.Label();
            this.LabelHrRate = new System.Windows.Forms.Label();
            this.TextBoxMI = new System.Windows.Forms.TextBox();
            this.NumericUpDownHrRate = new System.Windows.Forms.NumericUpDown();
            this.LabelPosType = new System.Windows.Forms.Label();
            this.RadioButtonFWS = new System.Windows.Forms.RadioButton();
            this.RadioButtonSWS = new System.Windows.Forms.RadioButton();
            this.RadioButtonMST = new System.Windows.Forms.RadioButton();
            this.RadioButtonHED = new System.Windows.Forms.RadioButton();
            this.RadioButtonHelp = new System.Windows.Forms.RadioButton();
            this.RadioButtonTutor1 = new System.Windows.Forms.RadioButton();
            this.RadioButtonTutor2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonTANF = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHrRate)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.Enabled = false;
            this.TextBoxFirstName.Location = new System.Drawing.Point(130, 81);
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(240, 22);
            this.TextBoxFirstName.TabIndex = 2;
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.Location = new System.Drawing.Point(12, 84);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(80, 17);
            this.LabelFirstName.TabIndex = 1;
            this.LabelFirstName.Text = "First Name:";
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.Location = new System.Drawing.Point(12, 170);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(80, 17);
            this.LabelLastName.TabIndex = 2;
            this.LabelLastName.Text = "Last Name:";
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.Enabled = false;
            this.TextBoxLastName.Location = new System.Drawing.Point(130, 167);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(240, 22);
            this.TextBoxLastName.TabIndex = 3;
            // 
            // LabelCardID
            // 
            this.LabelCardID.AutoSize = true;
            this.LabelCardID.Location = new System.Drawing.Point(12, 56);
            this.LabelCardID.Name = "LabelCardID";
            this.LabelCardID.Size = new System.Drawing.Size(112, 17);
            this.LabelCardID.TabIndex = 4;
            this.LabelCardID.Text = "Card/Student ID:";
            // 
            // TextBoxCardID
            // 
            this.TextBoxCardID.Location = new System.Drawing.Point(130, 53);
            this.TextBoxCardID.Name = "TextBoxCardID";
            this.TextBoxCardID.Size = new System.Drawing.Size(240, 22);
            this.TextBoxCardID.TabIndex = 1;
            this.TextBoxCardID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxCardID_KeyDown);
            this.TextBoxCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Helper.OnKeyPress);
            // 
            // LabelTip
            // 
            this.LabelTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTip.Location = new System.Drawing.Point(13, 13);
            this.LabelTip.Name = "LabelTip";
            this.LabelTip.Size = new System.Drawing.Size(357, 37);
            this.LabelTip.TabIndex = 6;
            this.LabelTip.Text = "Scan your card to retrieve your info. Leading and trailing spaces are removed.";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(0, 360);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(382, 27);
            this.ButtonSave.TabIndex = 14;
            this.ButtonSave.Text = "Save Card Edits";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelSeparator
            // 
            this.LabelSeparator.Location = new System.Drawing.Point(12, 127);
            this.LabelSeparator.Name = "LabelSeparator";
            this.LabelSeparator.Size = new System.Drawing.Size(358, 37);
            this.LabelSeparator.TabIndex = 7;
            this.LabelSeparator.Text = "Optional Info\r\n(used to fill out respective fields in time sheet)";
            this.LabelSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelMI
            // 
            this.LabelMI.AutoSize = true;
            this.LabelMI.Location = new System.Drawing.Point(12, 198);
            this.LabelMI.Name = "LabelMI";
            this.LabelMI.Size = new System.Drawing.Size(89, 17);
            this.LabelMI.TabIndex = 8;
            this.LabelMI.Text = "Middle Initial:";
            // 
            // LabelHrRate
            // 
            this.LabelHrRate.AutoSize = true;
            this.LabelHrRate.Location = new System.Drawing.Point(12, 225);
            this.LabelHrRate.Name = "LabelHrRate";
            this.LabelHrRate.Size = new System.Drawing.Size(87, 17);
            this.LabelHrRate.TabIndex = 9;
            this.LabelHrRate.Text = "Hourly Rate:";
            // 
            // TextBoxMI
            // 
            this.TextBoxMI.Enabled = false;
            this.TextBoxMI.Location = new System.Drawing.Point(130, 195);
            this.TextBoxMI.Name = "TextBoxMI";
            this.TextBoxMI.Size = new System.Drawing.Size(240, 22);
            this.TextBoxMI.TabIndex = 4;
            // 
            // NumericUpDownHrRate
            // 
            this.NumericUpDownHrRate.DecimalPlaces = 2;
            this.NumericUpDownHrRate.Enabled = false;
            this.NumericUpDownHrRate.Location = new System.Drawing.Point(130, 223);
            this.NumericUpDownHrRate.Name = "NumericUpDownHrRate";
            this.NumericUpDownHrRate.Size = new System.Drawing.Size(240, 22);
            this.NumericUpDownHrRate.TabIndex = 5;
            // 
            // LabelPosType
            // 
            this.LabelPosType.AutoSize = true;
            this.LabelPosType.Location = new System.Drawing.Point(12, 253);
            this.LabelPosType.Name = "LabelPosType";
            this.LabelPosType.Size = new System.Drawing.Size(98, 17);
            this.LabelPosType.TabIndex = 13;
            this.LabelPosType.Text = "Position Type:";
            // 
            // RadioButtonFWS
            // 
            this.RadioButtonFWS.AutoSize = true;
            this.RadioButtonFWS.Enabled = false;
            this.RadioButtonFWS.Location = new System.Drawing.Point(130, 251);
            this.RadioButtonFWS.Name = "RadioButtonFWS";
            this.RadioButtonFWS.Size = new System.Drawing.Size(59, 21);
            this.RadioButtonFWS.TabIndex = 6;
            this.RadioButtonFWS.TabStop = true;
            this.RadioButtonFWS.Text = "FWS";
            this.RadioButtonFWS.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSWS
            // 
            this.RadioButtonSWS.AutoSize = true;
            this.RadioButtonSWS.Enabled = false;
            this.RadioButtonSWS.Location = new System.Drawing.Point(195, 251);
            this.RadioButtonSWS.Name = "RadioButtonSWS";
            this.RadioButtonSWS.Size = new System.Drawing.Size(60, 21);
            this.RadioButtonSWS.TabIndex = 7;
            this.RadioButtonSWS.TabStop = true;
            this.RadioButtonSWS.Text = "SWS";
            this.RadioButtonSWS.UseVisualStyleBackColor = true;
            // 
            // RadioButtonMST
            // 
            this.RadioButtonMST.AutoSize = true;
            this.RadioButtonMST.Enabled = false;
            this.RadioButtonMST.Location = new System.Drawing.Point(261, 251);
            this.RadioButtonMST.Name = "RadioButtonMST";
            this.RadioButtonMST.Size = new System.Drawing.Size(93, 21);
            this.RadioButtonMST.TabIndex = 8;
            this.RadioButtonMST.TabStop = true;
            this.RadioButtonMST.Text = "SWS MST";
            this.RadioButtonMST.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHED
            // 
            this.RadioButtonHED.AutoSize = true;
            this.RadioButtonHED.Enabled = false;
            this.RadioButtonHED.Location = new System.Drawing.Point(130, 278);
            this.RadioButtonHED.Name = "RadioButtonHED";
            this.RadioButtonHED.Size = new System.Drawing.Size(93, 21);
            this.RadioButtonHED.TabIndex = 9;
            this.RadioButtonHED.TabStop = true;
            this.RadioButtonHED.Text = "SWS HED";
            this.RadioButtonHED.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHelp
            // 
            this.RadioButtonHelp.AutoSize = true;
            this.RadioButtonHelp.Enabled = false;
            this.RadioButtonHelp.Location = new System.Drawing.Point(261, 278);
            this.RadioButtonHelp.Name = "RadioButtonHelp";
            this.RadioButtonHelp.Size = new System.Drawing.Size(111, 21);
            this.RadioButtonHelp.TabIndex = 10;
            this.RadioButtonHelp.TabStop = true;
            this.RadioButtonHelp.Text = "Student Help";
            this.RadioButtonHelp.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTutor1
            // 
            this.RadioButtonTutor1.AutoSize = true;
            this.RadioButtonTutor1.Enabled = false;
            this.RadioButtonTutor1.Location = new System.Drawing.Point(130, 305);
            this.RadioButtonTutor1.Name = "RadioButtonTutor1";
            this.RadioButtonTutor1.Size = new System.Drawing.Size(75, 21);
            this.RadioButtonTutor1.TabIndex = 11;
            this.RadioButtonTutor1.TabStop = true;
            this.RadioButtonTutor1.Text = "Tutor 1";
            this.RadioButtonTutor1.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTutor2
            // 
            this.RadioButtonTutor2.AutoSize = true;
            this.RadioButtonTutor2.Enabled = false;
            this.RadioButtonTutor2.Location = new System.Drawing.Point(261, 305);
            this.RadioButtonTutor2.Name = "RadioButtonTutor2";
            this.RadioButtonTutor2.Size = new System.Drawing.Size(75, 21);
            this.RadioButtonTutor2.TabIndex = 12;
            this.RadioButtonTutor2.TabStop = true;
            this.RadioButtonTutor2.Text = "Tutor 2";
            this.RadioButtonTutor2.UseVisualStyleBackColor = true;
            // 
            // RadioButtonTANF
            // 
            this.RadioButtonTANF.AutoSize = true;
            this.RadioButtonTANF.Enabled = false;
            this.RadioButtonTANF.Location = new System.Drawing.Point(130, 332);
            this.RadioButtonTANF.Name = "RadioButtonTANF";
            this.RadioButtonTANF.Size = new System.Drawing.Size(118, 21);
            this.RadioButtonTANF.TabIndex = 13;
            this.RadioButtonTANF.TabStop = true;
            this.RadioButtonTANF.Text = "TANF Student";
            this.RadioButtonTANF.UseVisualStyleBackColor = true;
            // 
            // FormEditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 387);
            this.Controls.Add(this.RadioButtonTANF);
            this.Controls.Add(this.RadioButtonTutor2);
            this.Controls.Add(this.RadioButtonTutor1);
            this.Controls.Add(this.RadioButtonHelp);
            this.Controls.Add(this.RadioButtonHED);
            this.Controls.Add(this.RadioButtonMST);
            this.Controls.Add(this.RadioButtonSWS);
            this.Controls.Add(this.RadioButtonFWS);
            this.Controls.Add(this.LabelPosType);
            this.Controls.Add(this.NumericUpDownHrRate);
            this.Controls.Add(this.TextBoxMI);
            this.Controls.Add(this.LabelHrRate);
            this.Controls.Add(this.LabelMI);
            this.Controls.Add(this.LabelSeparator);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelTip);
            this.Controls.Add(this.TextBoxCardID);
            this.Controls.Add(this.LabelCardID);
            this.Controls.Add(this.TextBoxLastName);
            this.Controls.Add(this.LabelLastName);
            this.Controls.Add(this.LabelFirstName);
            this.Controls.Add(this.TextBoxFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 432);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 432);
            this.Name = "FormEditCard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Card";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditCard_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHrRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxFirstName;
        private System.Windows.Forms.Label LabelFirstName;
        private System.Windows.Forms.Label LabelLastName;
        private System.Windows.Forms.TextBox TextBoxLastName;
        private System.Windows.Forms.Label LabelCardID;
        private System.Windows.Forms.TextBox TextBoxCardID;
        private System.Windows.Forms.Label LabelTip;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label LabelSeparator;
        private System.Windows.Forms.Label LabelMI;
        private System.Windows.Forms.Label LabelHrRate;
        private System.Windows.Forms.TextBox TextBoxMI;
        private System.Windows.Forms.NumericUpDown NumericUpDownHrRate;
        private System.Windows.Forms.Label LabelPosType;
        private System.Windows.Forms.RadioButton RadioButtonFWS;
        private System.Windows.Forms.RadioButton RadioButtonSWS;
        private System.Windows.Forms.RadioButton RadioButtonMST;
        private System.Windows.Forms.RadioButton RadioButtonHED;
        private System.Windows.Forms.RadioButton RadioButtonHelp;
        private System.Windows.Forms.RadioButton RadioButtonTutor1;
        private System.Windows.Forms.RadioButton RadioButtonTutor2;
        private System.Windows.Forms.RadioButton RadioButtonTANF;
    }
}