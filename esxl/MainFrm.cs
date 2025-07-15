using esxl.Help;
using System.Threading.Tasks;

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
                Title = "ѡ��Excel�ļ�",
                Filter = "Excel�ļ�|*.xlsx;*.xlsm;*.xls"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = dialog.FileName;
                ExcelContext.InitContext(txtFilePath.Text);
                var open = ExcelContext.ContextFile.OpenExcel();
                if (!open)
                {
                    MessageBox.Show("�ļ���ʧ��");
                    return;
                }
            }


        }

        private void btnGroupBy_Click(object sender, EventArgs e)
        {
            if (!showFeatureCheck())
            {
                return;
            }
            var groupByFrm = new GroupByFrm();
            groupByFrm.ShowDialog(this);

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

            Task.Run(async () =>
            {
                Thread.Sleep(1000);
                var release = await Updater.CheckUpdateAsync();
                if (release == null)
                {
                    return;
                }
                var result = MessageBox.Show($"�����°汾{release.TagName}���Ƿ���£�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                var download = await Updater.DownloadAndExtractAsync(release.Assets[0].BrowserDownloadUrl);
                if (download)
                {
                    Updater.UpdateVersion(release.TagName);
                    Updater.RestartApplication();
                }
                return;
            });

        }

        private void btnSheetSave_Click(object sender, EventArgs e)
        {
            if (!showFeatureCheck())
            {
                 return;
            }
            SplitFrm frm = new();
            frm.ShowDialog(this);

        }


        private bool showFeatureCheck()
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("��ѡ��Excel�ļ�", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


    }
}
