namespace esxl
{
    partial class GroupByFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileListCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sheets = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.column = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.outputTxt = new System.Windows.Forms.TextBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件：";
            // 
            // fileListCombo
            // 
            this.fileListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileListCombo.FormattingEnabled = true;
            this.fileListCombo.Location = new System.Drawing.Point(130, 18);
            this.fileListCombo.Margin = new System.Windows.Forms.Padding(4);
            this.fileListCombo.Name = "fileListCombo";
            this.fileListCombo.Size = new System.Drawing.Size(260, 32);
            this.fileListCombo.TabIndex = 1;
            this.fileListCombo.SelectedIndexChanged += new System.EventHandler(this.fileListCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择Sheet：";
            // 
            // sheets
            // 
            this.sheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheets.FormattingEnabled = true;
            this.sheets.Location = new System.Drawing.Point(548, 18);
            this.sheets.Margin = new System.Windows.Forms.Padding(4);
            this.sheets.Name = "sheets";
            this.sheets.Size = new System.Drawing.Size(218, 32);
            this.sheets.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(804, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "选择分组列：";
            // 
            // column
            // 
            this.column.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.column.FormattingEnabled = true;
            this.column.Location = new System.Drawing.Point(946, 18);
            this.column.Margin = new System.Windows.Forms.Padding(4);
            this.column.Name = "column";
            this.column.Size = new System.Drawing.Size(130, 32);
            this.column.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "输出目录：";
            // 
            // outputTxt
            // 
            this.outputTxt.Location = new System.Drawing.Point(130, 68);
            this.outputTxt.Margin = new System.Windows.Forms.Padding(4);
            this.outputTxt.Name = "outputTxt";
            this.outputTxt.Size = new System.Drawing.Size(734, 30);
            this.outputTxt.TabIndex = 7;
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(874, 66);
            this.btnTarget.Margin = new System.Windows.Forms.Padding(4);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(118, 34);
            this.btnTarget.TabIndex = 8;
            this.btnTarget.Text = "选择目录";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1022, 66);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 34);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1022, 558);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 34);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(896, 558);
            this.checkBtn.Margin = new System.Windows.Forms.Padding(4);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(118, 34);
            this.checkBtn.TabIndex = 11;
            this.checkBtn.Text = "检查";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(30, 120);
            this.txtLogs.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1110, 430);
            this.txtLogs.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 558);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(856, 34);
            this.progressBar.TabIndex = 13;
            this.progressBar.Visible = false;
            // 
            // GroupByFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 608);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.outputTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.column);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sheets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileListCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupByFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "按列分组拆分";
            this.Load += new System.EventHandler(this.GroupByFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fileListCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sheets;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox column;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputTxt;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}