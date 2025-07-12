using esxl.Help;

namespace esxl
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }



        private void btnSelect_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "选择Excel文件",
                Filter = "Excel文件|*.xlsx;*.xlsm;*.xls"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
                ExcelContext.InitContext(txtFilePath.Text);
                var open=ExcelContext.ContextFile.OpenExcel();
                if (!open)
                {
                    MessageBox.Show("文件打开失败");
                    return;
                }
            }


        }

        private void btnGroupBy_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("请选择Excel文件", "", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var groupByFrm = new GroupByFrm();
            groupByFrm.ShowDialog(this);

        }
    }
}
