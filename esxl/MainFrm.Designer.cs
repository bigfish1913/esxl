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
            btnSplit = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnSplit
            // 
            btnSplit.Location = new Point(141, 114);
            btnSplit.Name = "btnSplit";
            btnSplit.Size = new Size(112, 34);
            btnSplit.TabIndex = 0;
            btnSplit.Text = "Sheet拆分保存";
            btnSplit.UseVisualStyleBackColor = true;
            btnSplit.Click += btnSplit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(314, 114);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "检查更新";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 702);
            Controls.Add(btnUpdate);
            Controls.Add(btnSplit);
            Name = "MainFrm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSplit;
        private Button btnUpdate;
    }
}
