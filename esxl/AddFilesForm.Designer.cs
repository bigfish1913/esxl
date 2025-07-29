namespace esxl
{
    partial class AddFilesForm
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
            directAddRadioButton = new RadioButton();
            scanAddRadioButton = new RadioButton();
            browseFileButton = new Button();
            browseFolderButton = new Button();
            directoryTextBox = new TextBox();
            fileTreeView = new TreeView();
            fileListBox = new ListBox();
            selectAllButton = new Button();
            deselectAllButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            statusLabel = new Label();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // directAddRadioButton
            // 
            directAddRadioButton.AutoSize = true;
            directAddRadioButton.Location = new Point(12, 12);
            directAddRadioButton.Name = "directAddRadioButton";
            directAddRadioButton.Size = new Size(143, 28);
            directAddRadioButton.TabIndex = 0;
            directAddRadioButton.TabStop = true;
            directAddRadioButton.Text = "直接添加文件";
            directAddRadioButton.UseVisualStyleBackColor = true;
            directAddRadioButton.CheckedChanged += directAddRadioButton_CheckedChanged;
            // 
            // scanAddRadioButton
            // 
            scanAddRadioButton.AutoSize = true;
            scanAddRadioButton.Location = new Point(12, 46);
            scanAddRadioButton.Name = "scanAddRadioButton";
            scanAddRadioButton.Size = new Size(143, 28);
            scanAddRadioButton.TabIndex = 1;
            scanAddRadioButton.TabStop = true;
            scanAddRadioButton.Text = "扫描目录添加";
            scanAddRadioButton.UseVisualStyleBackColor = true;
            scanAddRadioButton.CheckedChanged += scanAddRadioButton_CheckedChanged;
            // 
            // browseFileButton
            // 
            browseFileButton.Location = new Point(177, 6);
            browseFileButton.Name = "browseFileButton";
            browseFileButton.Size = new Size(90, 34);
            browseFileButton.TabIndex = 2;
            browseFileButton.Text = "浏览...";
            browseFileButton.UseVisualStyleBackColor = true;
            browseFileButton.Click += browseFileButton_Click;
            // 
            // browseFolderButton
            // 
            browseFolderButton.Enabled = false;
            browseFolderButton.Location = new Point(177, 44);
            browseFolderButton.Name = "browseFolderButton";
            browseFolderButton.Size = new Size(90, 34);
            browseFolderButton.TabIndex = 3;
            browseFolderButton.Text = "浏览...";
            browseFolderButton.UseVisualStyleBackColor = true;
            browseFolderButton.Click += browseFolderButton_Click;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            directoryTextBox.Location = new Point(298, 48);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.ReadOnly = true;
            directoryTextBox.Size = new Size(729, 30);
            directoryTextBox.TabIndex = 4;
            // 
            // fileTreeView
            // 
            fileTreeView.CheckBoxes = true;
            fileTreeView.Dock = DockStyle.Fill;
            fileTreeView.Location = new Point(0, 0);
            fileTreeView.Name = "fileTreeView";
            fileTreeView.Size = new Size(689, 652);
            fileTreeView.TabIndex = 5;
            fileTreeView.AfterCheck += fileTreeView_AfterCheck;
            // 
            // fileListBox
            // 
            fileListBox.Dock = DockStyle.Fill;
            fileListBox.FormattingEnabled = true;
            fileListBox.Location = new Point(0, 0);
            fileListBox.Name = "fileListBox";
            fileListBox.SelectionMode = SelectionMode.None;
            fileListBox.Size = new Size(336, 652);
            fileListBox.TabIndex = 6;
            // 
            // selectAllButton
            // 
            selectAllButton.Enabled = false;
            selectAllButton.Location = new Point(798, 12);
            selectAllButton.Name = "selectAllButton";
            selectAllButton.Size = new Size(90, 34);
            selectAllButton.TabIndex = 7;
            selectAllButton.Text = "全选";
            selectAllButton.UseVisualStyleBackColor = true;
            selectAllButton.Click += selectAllButton_Click;
            // 
            // deselectAllButton
            // 
            deselectAllButton.Enabled = false;
            deselectAllButton.Location = new Point(919, 12);
            deselectAllButton.Name = "deselectAllButton";
            deselectAllButton.Size = new Size(108, 34);
            deselectAllButton.TabIndex = 8;
            deselectAllButton.Text = "取消全选";
            deselectAllButton.UseVisualStyleBackColor = true;
            deselectAllButton.Click += deselectAllButton_Click;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Enabled = false;
            okButton.Location = new Point(855, 755);
            okButton.Name = "okButton";
            okButton.Size = new Size(90, 34);
            okButton.TabIndex = 9;
            okButton.Text = "确定";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(951, 755);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 34);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 768);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 24);
            statusLabel.TabIndex = 11;
            statusLabel.Text = "未选择文件";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 744);
            label1.Name = "label1";
            label1.Size = new Size(86, 24);
            label1.TabIndex = 12;
            label1.Text = "已选文件:";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 84);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(fileTreeView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(fileListBox);
            splitContainer1.Size = new Size(1029, 652);
            splitContainer1.SplitterDistance = 689;
            splitContainer1.TabIndex = 14;
            // 
            // AddFilesForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 801);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Controls.Add(statusLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(deselectAllButton);
            Controls.Add(selectAllButton);
            Controls.Add(directoryTextBox);
            Controls.Add(browseFolderButton);
            Controls.Add(browseFileButton);
            Controls.Add(scanAddRadioButton);
            Controls.Add(directAddRadioButton);
            Name = "AddFilesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "添加文件";
            Load += AddFilesForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton directAddRadioButton;
        private System.Windows.Forms.RadioButton scanAddRadioButton;
        private System.Windows.Forms.Button browseFileButton;
        private System.Windows.Forms.Button browseFolderButton;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button deselectAllButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}