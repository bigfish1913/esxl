namespace esxl
{
    partial class MergeFilesForm
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
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileNameColumn = new System.Windows.Forms.ColumnHeader();
            this.sizeColumn = new System.Windows.Forms.ColumnHeader();
            this.sheetsColumn = new System.Windows.Forms.ColumnHeader();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.mergeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.mergeIntoSingleSheetCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // fileListView
            // 
            this.fileListView.CheckBoxes = true;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumn,
            this.sizeColumn,
            this.sheetsColumn});
            this.fileListView.FullRowSelect = true;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(12, 41);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(776, 307);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.Text = "文件名";
            this.fileNameColumn.Width = 300;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "大小";
            this.sizeColumn.Width = 100;
            // 
            // sheetsColumn
            // 
            this.sheetsColumn.Text = "工作表数量";
            this.sheetsColumn.Width = 120;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(12, 12);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(64, 28);
            this.selectAllCheckBox.TabIndex = 1;
            this.selectAllCheckBox.Text = "全选";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "输出目录：";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(118, 360);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(512, 30);
            this.outputTextBox.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(636, 358);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 35);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "浏览";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // mergeButton
            // 
            this.mergeButton.Location = new System.Drawing.Point(524, 412);
            this.mergeButton.Name = "mergeButton";
            this.mergeButton.Size = new System.Drawing.Size(112, 34);
            this.mergeButton.TabIndex = 5;
            this.mergeButton.Text = "合并";
            this.mergeButton.UseVisualStyleBackColor = true;
            this.mergeButton.Click += new System.EventHandler(this.mergeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(676, 412);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 34);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "关闭";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(118, 412);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(386, 34);
            this.progressBar.TabIndex = 7;
            this.progressBar.Visible = false;
            // 
            // mergeIntoSingleSheetCheckBox
            // 
            this.mergeIntoSingleSheetCheckBox.AutoSize = true;
            this.mergeIntoSingleSheetCheckBox.Location = new System.Drawing.Point(118, 395);
            this.mergeIntoSingleSheetCheckBox.Name = "mergeIntoSingleSheetCheckBox";
            this.mergeIntoSingleSheetCheckBox.Size = new System.Drawing.Size(236, 28);
            this.mergeIntoSingleSheetCheckBox.TabIndex = 8;
            this.mergeIntoSingleSheetCheckBox.Text = "合并为单个工作表（所有数据）";
            this.mergeIntoSingleSheetCheckBox.UseVisualStyleBackColor = true;
            // 
            // MergeFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.mergeIntoSingleSheetCheckBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.mergeButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.fileListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeFilesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "合并Excel文件";
            this.Load += new System.EventHandler(this.MergeFilesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader fileNameColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader sheetsColumn;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button mergeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox mergeIntoSingleSheetCheckBox;
    }
}