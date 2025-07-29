namespace esxl
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sheetSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnGroupSplit = new System.Windows.Forms.Button();
            this.btnSheetSplit = new System.Windows.Forms.Button();
            this.btnMergeFiles = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fileInfoTabPage = new System.Windows.Forms.TabPage();
            this.fileInfoTextBox = new System.Windows.Forms.TextBox();
            this.filePreviewTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.fileTree = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.fileInfoTabPage.SuspendLayout();
            this.filePreviewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1881, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupSplitToolStripMenuItem,
            this.sheetSplitToolStripMenuItem,
            this.mergeFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.fileToolStripMenuItem.Text = "文件(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.newToolStripMenuItem.Text = "新建(&N)";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.openToolStripMenuItem.Text = "打开(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(225, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.saveToolStripMenuItem.Text = "保存(&S)";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            //this.saveAsToolStripMenuItem.Image = global::esxl.Properties.Resources.SaveAs;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.saveAsToolStripMenuItem.Text = "另存为(&A)";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupSplitToolStripMenuItem,
            this.sheetSplitToolStripMenuItem,
            this.mergeFilesToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.processToolStripMenuItem.Text = "处理(&P)";
            // 
            // groupSplitToolStripMenuItem
            // 
            this.groupSplitToolStripMenuItem.Name = "groupSplitToolStripMenuItem";
            this.groupSplitToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.groupSplitToolStripMenuItem.Text = "按分组拆分文件";
            this.groupSplitToolStripMenuItem.Click += new System.EventHandler(this.groupSplitToolStripMenuItem_Click);
            // 
            // sheetSplitToolStripMenuItem
            // 
            this.sheetSplitToolStripMenuItem.Name = "sheetSplitToolStripMenuItem";
            this.sheetSplitToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.sheetSplitToolStripMenuItem.Text = "按Sheet保存文件";
            this.sheetSplitToolStripMenuItem.Click += new System.EventHandler(this.sheetSplitToolStripMenuItem_Click);
            // 
            // mergeFilesToolStripMenuItem
            // 
            this.mergeFilesToolStripMenuItem.Name = "mergeFilesToolStripMenuItem";
            this.mergeFilesToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.mergeFilesToolStripMenuItem.Text = "合并Excel文件";
            this.mergeFilesToolStripMenuItem.Click += new System.EventHandler(this.mergeFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 30);
            this.exitToolStripMenuItem.Text = "退出(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1881, 1294);
            this.splitContainer1.SplitterDistance = 1156;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnMergeFiles);
            this.splitContainer2.Panel1.Controls.Add(this.btnSheetSplit);
            this.splitContainer2.Panel1.Controls.Add(this.btnGroupSplit);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1881, 1156);
            this.splitContainer2.SplitterDistance = 120;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnGroupSplit
            // 
            this.btnGroupSplit.Location = new System.Drawing.Point(30, 30);
            this.btnGroupSplit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGroupSplit.Name = "btnGroupSplit";
            this.btnGroupSplit.Size = new System.Drawing.Size(150, 60);
            this.btnGroupSplit.TabIndex = 0;
            this.btnGroupSplit.Text = "按分组拆分";
            this.btnGroupSplit.UseVisualStyleBackColor = true;
            this.btnGroupSplit.Click += new System.EventHandler(this.groupSplitToolStripMenuItem_Click);
            // 
            // btnSheetSplit
            // 
            this.btnSheetSplit.Location = new System.Drawing.Point(210, 30);
            this.btnSheetSplit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSheetSplit.Name = "btnSheetSplit";
            this.btnSheetSplit.Size = new System.Drawing.Size(150, 60);
            this.btnSheetSplit.TabIndex = 1;
            this.btnSheetSplit.Text = "按Sheet保存";
            this.btnSheetSplit.UseVisualStyleBackColor = true;
            this.btnSheetSplit.Click += new System.EventHandler(this.sheetSplitToolStripMenuItem_Click);
            // 
            // btnMergeFiles
            // 
            this.btnMergeFiles.Location = new System.Drawing.Point(390, 30);
            this.btnMergeFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMergeFiles.Name = "btnMergeFiles";
            this.btnMergeFiles.Size = new System.Drawing.Size(150, 60);
            this.btnMergeFiles.TabIndex = 2;
            this.btnMergeFiles.Text = "合并Excel文件";
            this.btnMergeFiles.UseVisualStyleBackColor = true;
            this.btnMergeFiles.Click += new System.EventHandler(this.btnMergeFiles_Click);
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer3.Size = new System.Drawing.Size(1877, 1065);
            this.splitContainer3.SplitterDistance = 324;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.fileInfoTabPage);
            this.tabControl1.Controls.Add(this.filePreviewTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1547, 1065);
            this.tabControl1.TabIndex = 0;
            // 
            // fileInfoTabPage
            // 
            this.fileInfoTabPage.Controls.Add(this.fileInfoTextBox);
            this.fileInfoTabPage.Location = new System.Drawing.Point(4, 33);
            this.fileInfoTabPage.Name = "fileInfoTabPage";
            this.fileInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileInfoTabPage.Size = new System.Drawing.Size(1539, 1028);
            this.fileInfoTabPage.TabIndex = 0;
            this.fileInfoTabPage.Text = "文件信息";
            this.fileInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // fileInfoTextBox
            // 
            this.fileInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileInfoTextBox.Location = new System.Drawing.Point(3, 3);
            this.fileInfoTextBox.Multiline = true;
            this.fileInfoTextBox.Name = "fileInfoTextBox";
            this.fileInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fileInfoTextBox.Size = new System.Drawing.Size(1533, 1022);
            this.fileInfoTextBox.TabIndex = 0;
            // 
            // filePreviewTabPage
            // 
            this.filePreviewTabPage.Controls.Add(this.dataGridView1);
            this.filePreviewTabPage.Location = new System.Drawing.Point(4, 33);
            this.filePreviewTabPage.Name = "filePreviewTabPage";
            this.filePreviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.filePreviewTabPage.Size = new System.Drawing.Size(1539, 1028);
            this.filePreviewTabPage.TabIndex = 1;
            this.filePreviewTabPage.Text = "数据预览";
            this.filePreviewTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1533, 1022);
            this.dataGridView1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer4.Panel1.Controls.Add(this.btnAdd);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.fileTree);
            this.splitContainer4.Size = new System.Drawing.Size(324, 1065);
            this.splitContainer4.SplitterDistance = 81;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(174, 27);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 34);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(28, 27);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // fileTree
            // 
            this.fileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTree.Location = new System.Drawing.Point(0, 0);
            this.fileTree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(320, 976);
            this.fileTree.TabIndex = 0;
            this.fileTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.fileTree_AfterCheck);
            this.fileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileTree_AfterSelect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1877, 106);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1881, 1329);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel处理工具";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.fileInfoTabPage.ResumeLayout(false);
            this.fileInfoTabPage.PerformLayout();
            this.filePreviewTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupSplitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sheetSplitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeFilesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnGroupSplit;
        private System.Windows.Forms.Button btnSheetSplit;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fileInfoTabPage;
        private System.Windows.Forms.TabPage filePreviewTabPage;
        private System.Windows.Forms.TextBox fileInfoTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMergeFiles;
    }
}