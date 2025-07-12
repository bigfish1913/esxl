namespace esxl
{
    partial class MainFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGroupBy = new Button();
            label1 = new Label();
            btnSelect = new Button();
            txtFilePath = new TextBox();
            SuspendLayout();
            // 
            // btnGroupBy
            // 
            btnGroupBy.Location = new Point(75, 114);
            btnGroupBy.Name = "btnGroupBy";
            btnGroupBy.Size = new Size(112, 34);
            btnGroupBy.TabIndex = 0;
            btnGroupBy.Text = "列同名分类保存";
            btnGroupBy.UseVisualStyleBackColor = true;
            btnGroupBy.Click += btnGroupBy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 39);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 5;
            label1.Text = "文件路径：";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(446, 34);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(51, 34);
            btnSelect.TabIndex = 4;
            btnSelect.Text = "...";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(137, 36);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(289, 30);
            txtFilePath.TabIndex = 3;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 702);
            Controls.Add(label1);
            Controls.Add(btnSelect);
            Controls.Add(txtFilePath);
            Controls.Add(btnGroupBy);
            Name = "MainFrm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGroupBy;
        private Label label1;
        private Button btnSelect;
        private TextBox txtFilePath;
    }
}
