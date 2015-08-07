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
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LabelStatus = new System.Windows.Forms.Label();
            this.LabelTip = new System.Windows.Forms.Label();
            this.LabelInput = new System.Windows.Forms.Label();
            this.TimerInputTimeout = new System.Windows.Forms.Timer(this.components);
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemManageCards = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewCard = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveCard = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemManageTime = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEditPast = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAddTime = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.Clock = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.dateBox = new System.Windows.Forms.Label();
            this.MenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelStatus
            // 
            this.LabelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Location = new System.Drawing.Point(0, 24);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(658, 195);
            this.LabelStatus.TabIndex = 0;
            this.LabelStatus.Text = "Waiting for card scan . . .";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTip
            // 
            this.LabelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTip.Location = new System.Drawing.Point(0, 219);
            this.LabelTip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTip.Name = "LabelTip";
            this.LabelTip.Size = new System.Drawing.Size(658, 144);
            this.LabelTip.TabIndex = 1;
            this.LabelTip.Text = "Scan a card or type in your Student ID to clock in or clock out.";
            this.LabelTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelInput
            // 
            this.LabelInput.AutoSize = true;
            this.LabelInput.Location = new System.Drawing.Point(9, 23);
            this.LabelInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelInput.Name = "LabelInput";
            this.LabelInput.Size = new System.Drawing.Size(36, 13);
            this.LabelInput.TabIndex = 2;
            this.LabelInput.Text = "input: ";
            // 
            // TimerInputTimeout
            // 
            this.TimerInputTimeout.Interval = 15000;
            this.TimerInputTimeout.Tick += new System.EventHandler(this.TimerInputTimeout_Tick);
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemManageCards,
            this.ToolStripMenuItemManageTime,
            this.ToolStripMenuItemReports,
            this.ToolStripMenuItemSettings,
            this.ToolStripMenuItemHelp});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuStripMain.Size = new System.Drawing.Size(658, 24);
            this.MenuStripMain.TabIndex = 3;
            this.MenuStripMain.Text = "Menu Strip";
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemExit});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.ToolStripMenuItemFile.Text = "&File";
            // 
            // ToolStripMenuItemExit
            // 
            this.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            this.ToolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.ToolStripMenuItemExit.Size = new System.Drawing.Size(129, 22);
            this.ToolStripMenuItemExit.Text = "E&xit";
            this.ToolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // ToolStripMenuItemManageCards
            // 
            this.ToolStripMenuItemManageCards.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewCard,
            this.ToolStripMenuItemEdit,
            this.ToolStripMenuItemRemoveCard});
            this.ToolStripMenuItemManageCards.Name = "ToolStripMenuItemManageCards";
            this.ToolStripMenuItemManageCards.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.ToolStripMenuItemManageCards.Size = new System.Drawing.Size(95, 20);
            this.ToolStripMenuItemManageCards.Text = "Manage &Cards";
            // 
            // ToolStripMenuItemNewCard
            // 
            this.ToolStripMenuItemNewCard.Name = "ToolStripMenuItemNewCard";
            this.ToolStripMenuItemNewCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.ToolStripMenuItemNewCard.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemNewCard.Text = "Add &new card";
            this.ToolStripMenuItemNewCard.Click += new System.EventHandler(this.ToolStripMenuItemNewCard_Click);
            // 
            // ToolStripMenuItemEdit
            // 
            this.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit";
            this.ToolStripMenuItemEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ToolStripMenuItemEdit.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemEdit.Text = "&Edit card";
            this.ToolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // ToolStripMenuItemRemoveCard
            // 
            this.ToolStripMenuItemRemoveCard.Name = "ToolStripMenuItemRemoveCard";
            this.ToolStripMenuItemRemoveCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.ToolStripMenuItemRemoveCard.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemRemoveCard.Text = "Re&move card";
            this.ToolStripMenuItemRemoveCard.Click += new System.EventHandler(this.ToolStripMenuItemRemoveCard_Click);
            // 
            // ToolStripMenuItemManageTime
            // 
            this.ToolStripMenuItemManageTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemEditPast,
            this.ToolStripMenuItemAddTime});
            this.ToolStripMenuItemManageTime.Name = "ToolStripMenuItemManageTime";
            this.ToolStripMenuItemManageTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToolStripMenuItemManageTime.Size = new System.Drawing.Size(92, 20);
            this.ToolStripMenuItemManageTime.Text = "Manage &Time";
            // 
            // ToolStripMenuItemEditPast
            // 
            this.ToolStripMenuItemEditPast.Name = "ToolStripMenuItemEditPast";
            this.ToolStripMenuItemEditPast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.ToolStripMenuItemEditPast.Size = new System.Drawing.Size(211, 22);
            this.ToolStripMenuItemEditPast.Text = "Edit &past time";
            this.ToolStripMenuItemEditPast.Click += new System.EventHandler(this.ToolStripMenuItemEditPast_Click);
            // 
            // ToolStripMenuItemAddTime
            // 
            this.ToolStripMenuItemAddTime.Name = "ToolStripMenuItemAddTime";
            this.ToolStripMenuItemAddTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.ToolStripMenuItemAddTime.Size = new System.Drawing.Size(211, 22);
            this.ToolStripMenuItemAddTime.Text = "Manually a&dd time";
            this.ToolStripMenuItemAddTime.Click += new System.EventHandler(this.ToolStripMenuItemAddTime_Click);
            // 
            // ToolStripMenuItemReports
            // 
            this.ToolStripMenuItemReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemGenerate});
            this.ToolStripMenuItemReports.Name = "ToolStripMenuItemReports";
            this.ToolStripMenuItemReports.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ToolStripMenuItemReports.Size = new System.Drawing.Size(59, 20);
            this.ToolStripMenuItemReports.Text = "&Reports";
            // 
            // ToolStripMenuItemGenerate
            // 
            this.ToolStripMenuItemGenerate.Name = "ToolStripMenuItemGenerate";
            this.ToolStripMenuItemGenerate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.ToolStripMenuItemGenerate.Size = new System.Drawing.Size(217, 22);
            this.ToolStripMenuItemGenerate.Text = "&Generate time sheet";
            this.ToolStripMenuItemGenerate.Click += new System.EventHandler(this.TimeSheetToolStripMenuItemGenerate_Click);
            // 
            // ToolStripMenuItemSettings
            // 
            this.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            this.ToolStripMenuItemSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.ToolStripMenuItemSettings.Size = new System.Drawing.Size(61, 20);
            this.ToolStripMenuItemSettings.Text = "&Settings";
            this.ToolStripMenuItemSettings.Visible = false;
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.ToolStripMenuItemHelp.Text = "&Help";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(145, 22);
            this.ToolStripMenuItemAbout.Text = "&About";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // Clock
            // 
            this.Clock.Dock = System.Windows.Forms.DockStyle.Top;
            this.Clock.Font = new System.Drawing.Font("Consolas", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock.Location = new System.Drawing.Point(0, 363);
            this.Clock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(658, 108);
            this.Clock.TabIndex = 2;
            this.Clock.Text = "Clock";
            this.Clock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // dateBox
            // 
            this.dateBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBox.Location = new System.Drawing.Point(0, 471);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(658, 42);
            this.dateBox.TabIndex = 4;
            this.dateBox.Text = "Date";
            this.dateBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 581);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.Clock);
            this.Controls.Add(this.LabelInput);
            this.Controls.Add(this.LabelTip);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.MenuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStripMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Barcode Clocking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Label LabelTip;
        private System.Windows.Forms.Label LabelInput;
        private System.Windows.Forms.Timer TimerInputTimeout;
        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemManageCards;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewCard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemoveCard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemReports;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGenerate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemManageTime;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEditPast;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddTime;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.Label Clock;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label dateBox;
    }
}