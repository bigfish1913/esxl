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
            column = new ComboBox();
            label1 = new Label();
            outputTxt = new TextBox();
            label2 = new Label();
            btnTarget = new Button();
            btnStart = new Button();
            btnClose = new Button();
            checkBtn = new Button();
            label3 = new Label();
            sheets = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            txtLogs = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // column
            // 
            column.FormattingEnabled = true;
            column.Location = new Point(343, 59);
            column.Name = "column";
            column.Size = new Size(95, 32);
            column.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 11);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 1;
            label1.Text = "拆分信息";
            // 
            // outputTxt
            // 
            outputTxt.Location = new Point(141, 282);
            outputTxt.Name = "outputTxt";
            outputTxt.Size = new Size(297, 30);
            outputTxt.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 285);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 3;
            label2.Text = "输出的位置";
            // 
            // btnTarget
            // 
            btnTarget.Location = new Point(466, 280);
            btnTarget.Name = "btnTarget";
            btnTarget.Size = new Size(73, 34);
            btnTarget.TabIndex = 4;
            btnTarget.Text = "...";
            btnTarget.UseVisualStyleBackColor = true;
            btnTarget.Click += btnTarget_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(141, 381);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(90, 34);
            btnStart.TabIndex = 5;
            btnStart.Text = "开始";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(339, 381);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(99, 34);
            btnClose.TabIndex = 6;
            btnClose.Text = "取消";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // checkBtn
            // 
            checkBtn.Location = new Point(466, 57);
            checkBtn.Name = "checkBtn";
            checkBtn.Size = new Size(73, 34);
            checkBtn.TabIndex = 7;
            checkBtn.Text = "预览";
            checkBtn.UseVisualStyleBackColor = true;
            checkBtn.Click += checkBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 270);
            label3.Name = "label3";
            label3.Size = new Size(0, 24);
            label3.TabIndex = 8;
            // 
            // sheets
            // 
            sheets.FormattingEnabled = true;
            sheets.Location = new Point(121, 59);
            sheets.Name = "sheets";
            sheets.Size = new Size(132, 32);
            sheets.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 67);
            label4.Name = "label4";
            label4.Size = new Size(70, 24);
            label4.TabIndex = 11;
            label4.Text = "Sheets:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(291, 62);
            label5.Name = "label5";
            label5.Size = new Size(46, 24);
            label5.TabIndex = 12;
            label5.Text = "列：";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtLogs);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(column);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(sheets);
            panel1.Controls.Add(outputTxt);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnTarget);
            panel1.Controls.Add(checkBtn);
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(577, 454);
            panel1.TabIndex = 13;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(28, 111);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.Size = new Size(511, 148);
            txtLogs.TabIndex = 13;
            // 
            // GroupByFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 454);
            Controls.Add(panel1);
            Name = "GroupByFrm";
            Text = "GroupBy";
            Load += GroupByFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox column;
        private Label label1;
        private TextBox outputTxt;
        private Label label2;
        private Button btnTarget;
        private Button btnStart;
        private Button btnClose;
        private Button checkBtn;
        private Label label3;
        private ComboBox sheets;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private TextBox txtLogs;
    }
}