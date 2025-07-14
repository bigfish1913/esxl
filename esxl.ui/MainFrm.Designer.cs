using ReaLTaiizor.Controls;
using ReaLTaiizor.Docking.Crown;

namespace esxl.ui
{
    partial class MainFrm
    {/// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            mnuMain = new CrownMenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuNewFile = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuClose = new ToolStripMenuItem();
            mnuView = new ToolStripMenuItem();
            mnuDialog = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            checkableToolStripMenuItem = new ToolStripMenuItem();
            checkableWithIconToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            checkedToolStripMenuItem = new ToolStripMenuItem();
            checkedWithIconToolStripMenuItem = new ToolStripMenuItem();
            mnuWindow = new ToolStripMenuItem();
            mnuProject = new ToolStripMenuItem();
            mnuProperties = new ToolStripMenuItem();
            mnuConsole = new ToolStripMenuItem();
            mnuLayers = new ToolStripMenuItem();
            mnuHistory = new ToolStripMenuItem();
            toolMain = new CrownToolStrip();
            btnNewFile = new ToolStripButton();
            stripMain = new CrownStatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel6 = new ToolStripStatusLabel();
            toolStripStatusLabel5 = new ToolStripStatusLabel();
            DockPanel = new CrownDockPanel();
            crownSeparator1 = new CrownSeparator();
            mnuMain.SuspendLayout();
            toolMain.SuspendLayout();
            stripMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.BackColor = Color.Transparent;
            mnuMain.ForeColor = Color.FromArgb(220, 220, 220);
            mnuMain.ImageScalingSize = new Size(24, 24);
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuTools, mnuWindow });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(3, 2, 0, 2);
            mnuMain.Size = new Size(1130, 32);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "crownMenuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.BackColor = Color.FromArgb(60, 63, 65);
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuNewFile, toolStripSeparator1, mnuClose });
            mnuFile.ForeColor = Color.FromArgb(220, 220, 220);
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(56, 28);
            mnuFile.Text = "&File";
            // 
            // mnuNewFile
            // 
            mnuNewFile.BackColor = Color.Transparent;
            mnuNewFile.ForeColor = Color.FromArgb(220, 220, 220);
            mnuNewFile.Name = "mnuNewFile";
            mnuNewFile.ShortcutKeys = Keys.Control | Keys.N;
            mnuNewFile.Size = new Size(249, 34);
            mnuNewFile.Text = "&New file";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor = Color.Transparent;
            toolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
            toolStripSeparator1.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(246, 6);
            // 
            // mnuClose
            // 
            mnuClose.BackColor = Color.Transparent;
            mnuClose.ForeColor = Color.FromArgb(220, 220, 220);
            mnuClose.Name = "mnuClose";
            mnuClose.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuClose.Size = new Size(249, 34);
            mnuClose.Text = "&Close";
            // 
            // mnuView
            // 
            mnuView.BackColor = Color.FromArgb(60, 63, 65);
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mnuDialog, themeToolStripMenuItem });
            mnuView.ForeColor = Color.FromArgb(220, 220, 220);
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(67, 28);
            mnuView.Text = "&View";
            // 
            // mnuDialog
            // 
            mnuDialog.BackColor = Color.Transparent;
            mnuDialog.ForeColor = Color.FromArgb(220, 220, 220);
            mnuDialog.Name = "mnuDialog";
            mnuDialog.Size = new Size(204, 34);
            mnuDialog.Text = "&Dialog test";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.BackColor = Color.Transparent;
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkToolStripMenuItem, lightToolStripMenuItem });
            themeToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(204, 34);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.BackColor = Color.Transparent;
            darkToolStripMenuItem.ForeColor = Color.FromArgb(20, 20, 20);
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(154, 34);
            darkToolStripMenuItem.Text = "Dark";
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.BackColor = Color.Transparent;
            lightToolStripMenuItem.ForeColor = Color.FromArgb(20, 20, 20);
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(154, 34);
            lightToolStripMenuItem.Text = "Light";
            // 
            // mnuTools
            // 
            mnuTools.BackColor = Color.FromArgb(60, 63, 65);
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { checkableToolStripMenuItem, checkableWithIconToolStripMenuItem, toolStripSeparator2, checkedToolStripMenuItem, checkedWithIconToolStripMenuItem });
            mnuTools.ForeColor = Color.FromArgb(220, 220, 220);
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(71, 28);
            mnuTools.Text = "&Tools";
            // 
            // checkableToolStripMenuItem
            // 
            checkableToolStripMenuItem.BackColor = Color.Transparent;
            checkableToolStripMenuItem.CheckOnClick = true;
            checkableToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            checkableToolStripMenuItem.Name = "checkableToolStripMenuItem";
            checkableToolStripMenuItem.Size = new Size(282, 34);
            checkableToolStripMenuItem.Text = "Checkable";
            // 
            // checkableWithIconToolStripMenuItem
            // 
            checkableWithIconToolStripMenuItem.BackColor = Color.Transparent;
            checkableWithIconToolStripMenuItem.CheckOnClick = true;
            checkableWithIconToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            checkableWithIconToolStripMenuItem.Name = "checkableWithIconToolStripMenuItem";
            checkableWithIconToolStripMenuItem.Size = new Size(282, 34);
            checkableWithIconToolStripMenuItem.Text = "Checkable with icon";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.BackColor = Color.Transparent;
            toolStripSeparator2.ForeColor = Color.FromArgb(220, 220, 220);
            toolStripSeparator2.Margin = new Padding(0, 0, 0, 1);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(279, 6);
            // 
            // checkedToolStripMenuItem
            // 
            checkedToolStripMenuItem.BackColor = Color.Transparent;
            checkedToolStripMenuItem.Checked = true;
            checkedToolStripMenuItem.CheckState = CheckState.Checked;
            checkedToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            checkedToolStripMenuItem.Name = "checkedToolStripMenuItem";
            checkedToolStripMenuItem.Size = new Size(282, 34);
            checkedToolStripMenuItem.Text = "Checked";
            // 
            // checkedWithIconToolStripMenuItem
            // 
            checkedWithIconToolStripMenuItem.BackColor = Color.Transparent;
            checkedWithIconToolStripMenuItem.Checked = true;
            checkedWithIconToolStripMenuItem.CheckState = CheckState.Checked;
            checkedWithIconToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
            checkedWithIconToolStripMenuItem.Name = "checkedWithIconToolStripMenuItem";
            checkedWithIconToolStripMenuItem.Size = new Size(282, 34);
            checkedWithIconToolStripMenuItem.Text = "Checked with icon";
            // 
            // mnuWindow
            // 
            mnuWindow.BackColor = Color.FromArgb(60, 63, 65);
            mnuWindow.DropDownItems.AddRange(new ToolStripItem[] { mnuProject, mnuProperties, mnuConsole, mnuLayers, mnuHistory });
            mnuWindow.ForeColor = Color.FromArgb(220, 220, 220);
            mnuWindow.Name = "mnuWindow";
            mnuWindow.Size = new Size(97, 28);
            mnuWindow.Text = "&Window";
            // 
            // mnuProject
            // 
            mnuProject.BackColor = Color.Transparent;
            mnuProject.ForeColor = Color.FromArgb(220, 220, 220);
            mnuProject.Name = "mnuProject";
            mnuProject.Size = new Size(246, 34);
            mnuProject.Text = "&Project Explorer";
            // 
            // mnuProperties
            // 
            mnuProperties.BackColor = Color.Transparent;
            mnuProperties.ForeColor = Color.FromArgb(220, 220, 220);
            mnuProperties.Name = "mnuProperties";
            mnuProperties.Size = new Size(246, 34);
            mnuProperties.Text = "P&roperties";
            // 
            // mnuConsole
            // 
            mnuConsole.BackColor = Color.Transparent;
            mnuConsole.ForeColor = Color.FromArgb(220, 220, 220);
            mnuConsole.Name = "mnuConsole";
            mnuConsole.Size = new Size(246, 34);
            mnuConsole.Text = "&Console";
            // 
            // mnuLayers
            // 
            mnuLayers.BackColor = Color.Transparent;
            mnuLayers.ForeColor = Color.FromArgb(220, 220, 220);
            mnuLayers.Name = "mnuLayers";
            mnuLayers.Size = new Size(246, 34);
            mnuLayers.Text = "&Layers";
            // 
            // mnuHistory
            // 
            mnuHistory.BackColor = Color.Transparent;
            mnuHistory.ForeColor = Color.FromArgb(220, 220, 220);
            mnuHistory.Image = (Image)resources.GetObject("mnuHistory.Image");
            mnuHistory.Name = "mnuHistory";
            mnuHistory.Size = new Size(246, 34);
            mnuHistory.Text = "&History";
            // 
            // toolMain
            // 
            toolMain.AutoSize = false;
            toolMain.BackColor = Color.FromArgb(60, 63, 65);
            toolMain.ForeColor = Color.FromArgb(220, 220, 220);
            toolMain.GripStyle = ToolStripGripStyle.Hidden;
            toolMain.ImageScalingSize = new Size(24, 24);
            toolMain.Items.AddRange(new ToolStripItem[] { btnNewFile });
            toolMain.Location = new Point(0, 34);
            toolMain.Name = "toolMain";
            toolMain.Padding = new Padding(5, 0, 1, 0);
            toolMain.Size = new Size(1130, 28);
            toolMain.TabIndex = 1;
            toolMain.Text = "crownToolStrip1";
            // 
            // btnNewFile
            // 
            btnNewFile.AutoSize = false;
            btnNewFile.BackColor = Color.FromArgb(60, 63, 65);
            btnNewFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNewFile.ForeColor = Color.FromArgb(220, 220, 220);
            btnNewFile.ImageTransparentColor = Color.Magenta;
            btnNewFile.Name = "btnNewFile";
            btnNewFile.Size = new Size(24, 24);
            btnNewFile.Text = "New file";
            // 
            // stripMain
            // 
            stripMain.AutoSize = false;
            stripMain.BackColor = Color.Transparent;
            stripMain.ForeColor = Color.FromArgb(220, 220, 220);
            stripMain.ImageScalingSize = new Size(24, 24);
            stripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel6, toolStripStatusLabel5 });
            stripMain.Location = new Point(0, 819);
            stripMain.Name = "stripMain";
            stripMain.Padding = new Padding(0, 5, 0, 3);
            stripMain.Size = new Size(1130, 24);
            stripMain.SizingGrip = false;
            stripMain.TabIndex = 2;
            stripMain.Text = "crownStatusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.AutoSize = false;
            toolStripStatusLabel1.Margin = new Padding(1, 0, 50, 0);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(39, 16);
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel6
            // 
            toolStripStatusLabel6.Margin = new Padding(0, 0, 50, 2);
            toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            toolStripStatusLabel6.Size = new Size(912, 14);
            toolStripStatusLabel6.Spring = true;
            toolStripStatusLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            toolStripStatusLabel5.Margin = new Padding(0, 0, 1, 0);
            toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            toolStripStatusLabel5.Size = new Size(77, 16);
            toolStripStatusLabel5.Text = "120 MB";
            toolStripStatusLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DockPanel
            // 
            DockPanel.BackColor = Color.FromArgb(60, 63, 65);
            DockPanel.Dock = DockStyle.Fill;
            DockPanel.Location = new Point(0, 62);
            DockPanel.Name = "DockPanel";
            DockPanel.Size = new Size(1130, 757);
            DockPanel.TabIndex = 3;
            // 
            // crownSeparator1
            // 
            crownSeparator1.Dock = DockStyle.Top;
            crownSeparator1.Location = new Point(0, 32);
            crownSeparator1.Name = "crownSeparator1";
            crownSeparator1.Size = new Size(1130, 2);
            crownSeparator1.TabIndex = 4;
            crownSeparator1.Text = "crownSeparator1";
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1130, 843);
            Controls.Add(DockPanel);
            Controls.Add(stripMain);
            Controls.Add(toolMain);
            Controls.Add(crownSeparator1);
            Controls.Add(mnuMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuMain;
            MinimumSize = new Size(640, 480);
            Name = "MainFrm";
            Text = "Crown Theme";
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            toolMain.ResumeLayout(false);
            toolMain.PerformLayout();
            stripMain.ResumeLayout(false);
            stripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CrownMenuStrip mnuMain;
        private CrownToolStrip toolMain;
        private CrownStatusStrip stripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripButton btnNewFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNewFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private CrownDockPanel DockPanel;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuConsole;
        private System.Windows.Forms.ToolStripMenuItem mnuLayers;
        private System.Windows.Forms.ToolStripMenuItem mnuHistory;
        private CrownSeparator crownSeparator1;
        private System.Windows.Forms.ToolStripMenuItem checkableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkableWithIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkedWithIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;

    }
}
