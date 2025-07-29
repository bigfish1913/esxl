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
        // Store the currently selected file for grouping
        private ExcelFile selectedFile = null;

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
            // Populate the file selection combo box with all loaded files
            foreach (ExcelFile file in ExcelContext.GetAllFiles())
            {
                this.fileListCombo.Items.Add(System.IO.Path.GetFileName(file.FileName));
            }
            
            if (this.fileListCombo.Items.Count > 0)
            {
                this.fileListCombo.SelectedIndex = 0; // Select first file by default
            }
            
            // Initialize column selection (A-Z)
            for (int i = 0; i < 26; i++)
            {
                this.column.Items.Add(((char)('A' + i)));
            }
            
            if (this.column.Items.Count > 0)
            {
                this.column.SelectedIndex = 0; // Select first column by default
            }
        }

        private void fileListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When file selection changes, update the sheets list
            this.sheets.Items.Clear();
            
            if (this.fileListCombo.SelectedIndex >= 0)
            {
                string selectedFileName = this.fileListCombo.SelectedItem.ToString();
                selectedFile = ExcelContext.GetAllFiles()
                    .FirstOrDefault(f => System.IO.Path.GetFileName(f.FileName) == selectedFileName);
                
                if (selectedFile != null)
                {
                    // Populate sheets for the selected file
                    var sheetList = selectedFile.GetSheetList();
                    foreach (string sheetName in sheetList)
                    {
                        this.sheets.Items.Add(sheetName);
                    }
                    
                    if (this.sheets.Items.Count > 0)
                    {
                        this.sheets.SelectedIndex = 0; // Select first sheet by default
                        this.btnStart.Enabled = true;
                    }
                    else
                    {
                        this.btnStart.Enabled = false;
                    }
                }
            }
            else
            {
                this.btnStart.Enabled = false;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (this.outputTxt.Text.Trim() == "")
            {
                MessageBox.Show("请选择输出目录");
                return;
            }
            
            if (selectedFile == null)
            {
                MessageBox.Show("请选择要处理的Excel文件");
                return;
            }
            
            var sheetName = this.sheets.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sheetName))
            {
                MessageBox.Show("请选择要分组的sheet");
                return;
            }
            
            var key = string.Format("data_{0}_{1}_{2}", 
                System.IO.Path.GetFileName(selectedFile.FileName), 
                sheetName, 
                DateTime.Now.ToString("yyyyMMddHH"));
                
            // 显示进度条
            progressBar.Visible = true;
            btnStart.Enabled = false;

            try
            {
                // 异步执行处理
                var data = await Task.Run(() => {
                    return Cache.LoadData(key, () =>
                    {
                        var groupData = selectedFile.GroupDataByColumn(column.SelectedIndex, sheetName);
                        return groupData;
                    });
                });

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("没有数据");
                    return;
                }
                
                // 异步执行导出
                await Task.Run(() => {
                    selectedFile.ExportGroupData(sheetName, this.outputTxt.Text, data);
                });
                
                MessageBox.Show("处理完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"处理过程中出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏进度条
                progressBar.Visible = false;
                btnStart.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void checkBtn_Click(object sender, EventArgs e)
        {
            if (selectedFile == null)
            {
                MessageBox.Show("请选择要处理的Excel文件");
                return;
            }
            
            var sheetName = this.sheets.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(sheetName))
            {
                MessageBox.Show("请选择要分组的sheet");
                return;
            }
            
            var key = string.Format("data_{0}_{1}_{2}", 
                System.IO.Path.GetFileName(selectedFile.FileName), 
                sheetName, 
                DateTime.Now.ToString("yyyyMMddHH"));
                
            // 显示进度条
            progressBar.Visible = true;
            checkBtn.Enabled = false;

            try
            {
                // 异步执行处理
                var data = await Task.Run(() => {
                    return Cache.LoadData(key, () =>
                    {
                        var groupData = selectedFile.GroupDataByColumn(column.SelectedIndex, sheetName);
                        return groupData;
                    });
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
            catch (Exception ex)
            {
                MessageBox.Show($"检查过程中出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏进度条
                progressBar.Visible = false;
                checkBtn.Enabled = true;
            }
        }
         
    }
}