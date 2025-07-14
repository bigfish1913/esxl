namespace esxl
{
    partial class SplitFrm
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
            txtFilePath = new TextBox();
            btnSelect = new Button();
            label1 = new Label();
            btnStart = new Button();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(124, 62);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(289, 30);
            txtFilePath.TabIndex = 0;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(433, 60);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(51, 34);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "...";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 65);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 2;
            label1.Text = "输出路径：";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(196, 122);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 3;
            btnStart.Text = "开始";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // SplitFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 188);
            Controls.Add(btnStart);
            Controls.Add(label1);
            Controls.Add(btnSelect);
            Controls.Add(txtFilePath);
            Name = "SplitFrm";
            Text = "SplitFrm";
            Load += SplitFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilePath;
        private Button btnSelect;
        private Label label1;
        private Button btnStart;
    }
}