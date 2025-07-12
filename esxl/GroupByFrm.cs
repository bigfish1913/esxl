using esxl.Help;
using NPOI.SS.UserModel;
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
    public partial class GroupByFrm : Form
    {
        public GroupByFrm()
        {
            InitializeComponent();
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            var fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.outputTxt.Text = fd.SelectedPath;
                this.outputTxt.Focus();
            }

        }

        private void GroupByFrm_Load(object sender, EventArgs e)
        {
            ExcelContext.ContextFile.GetSheetList().ForEach(sheetName =>
            {
                this.sheets.Items.Add(sheetName);
                this.sheets.SelectedIndex = 0;
            });
            for (int i = 0; i < 26; i++)
            {
                this.column.Items.Add(((char)('A' + i)));
                this.column.SelectedIndex = 0;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.outputTxt.Text.Trim() == "")
            {
                MessageBox.Show("请选择输出目录");
                return;
            }
            var sheetName = this.sheets.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sheetName))
            {
                MessageBox.Show("请选择要分组的sheet");
                return;
            }
            var key = string.Format("data_{0}_{1}", sheetName, DateTime.Now.ToString("yyyyMMddHH"));
            var data = ExcelContext.LoadData(key, () =>
            {
                var groupData = ExcelContext.ContextFile.GroupDataByColumn(column.SelectedIndex, sheetName);
                return groupData;
            });
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            ExcelContext.ContextFile.ExportGroupData(sheetName, this.outputTxt.Text, data);


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            var sheetName = this.sheets.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sheetName))
            {
                this.btnStart.Enabled = false;
                MessageBox.Show("请选择要分组的sheet");
                return;
            }
            var key = string.Format("data_{0}_{1}", sheetName, DateTime.Now.ToString("yyyyMMddHH"));
            var data = ExcelContext.LoadData(key, () =>
            {
                var groupData= ExcelContext.ContextFile.GroupDataByColumn(column.SelectedIndex, sheetName);
                return groupData;
            });

            if (data == null || data.Count == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            var content = new StringBuilder();
            foreach (var item in data)
            {
                content.AppendLine(string.Format("拆分字段值：{0} :数量:{1}", item.Key, item.Value.Count));
            }
            this.txtLogs.Text = content.ToString() + "\n" + this.txtLogs.Text;
        }
         
    }


}
