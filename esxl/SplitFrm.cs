using esxl.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esxl
{
    public partial class SplitFrm : Form
    {
        public SplitFrm()
        {
            InitializeComponent();
        }

        private void SplitFrm_Load(object sender, EventArgs e)
        {
            this.Text = "Sheet拆分保存";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var op = new FolderBrowserDialog();
          
            if (op.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = op.SelectedPath;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("请选择输出目录");
                return;
            }
            ExcelContext.ContextFile.SplitSheetsToFiles(txtFilePath.Text);
            MessageBox.Show("处理完成");
            this.Hide();


        }
    }
}
