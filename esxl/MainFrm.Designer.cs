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
            label1 = new Label();
            btnSelect = new Button();
            txtFilePath = new TextBox();
            btnGroupBy = new Button();
            btnSheetSave = new Button();
            btnPublish = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 71);
            label1.Name = "label1";
            label1.Size = new Size(143, 24);
            label1.TabIndex = 13;
            label1.Text = "excel文件路径：";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(471, 65);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(50, 34);
            btnSelect.TabIndex = 12;
            btnSelect.Text = "...";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(161, 68);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(288, 30);
            txtFilePath.TabIndex = 11;
            // 
            // btnGroupBy
            // 
            btnGroupBy.Location = new Point(32, 146);
            btnGroupBy.Name = "btnGroupBy";
            btnGroupBy.Size = new Size(112, 34);
            btnGroupBy.TabIndex = 10;
            btnGroupBy.Text = "列同名分类保存";
            btnGroupBy.UseVisualStyleBackColor = true;
            btnGroupBy.Click += btnGroupBy_Click;
            // 
            // btnSheetSave
            // 
            btnSheetSave.Location = new Point(161, 146);
            btnSheetSave.Name = "btnSheetSave";
            btnSheetSave.Size = new Size(144, 34);
            btnSheetSave.TabIndex = 14;
            btnSheetSave.Text = "sheet保存文件";
            btnSheetSave.UseVisualStyleBackColor = true;
            btnSheetSave.Click += btnSheetSave_Click;
            // 
            // btnPublish
            // 
            btnPublish.Location = new Point(328, 146);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(112, 34);
            btnPublish.TabIndex = 15;
            btnPublish.Text = "发布到Gitee";
            btnPublish.UseVisualStyleBackColor = true;
            btnPublish.Click += btnPublish_Click;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 224);
            Controls.Add(btnPublish);
            Controls.Add(btnSheetSave);
            Controls.Add(label1);
            Controls.Add(btnSelect);
            Controls.Add(txtFilePath);
            Controls.Add(btnGroupBy);
            MinimumSize = new Size(176, 49);
            Name = "MainFrm";
            Text = "Form1";
            TransparencyKey = Color.Fuchsia;
            Load += MainFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSelect;
        private TextBox txtFilePath;
        private Button btnGroupBy;
        private Button btnSheetSave;
        private Button btnPublish;
    }
}
