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
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.SelectedPath;
                }
            }
        }

        private List<ExcelFile> GetExcelFilesSafely()
        {
            try
            {
                return ExcelContext.GetAllFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法加载Excel文件: {ex.Message}", "文件加载错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ExcelFile>();
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string outputDirectory = txtFilePath.Text;
            if (string.IsNullOrEmpty(outputDirectory))
            {
                MessageBox.Show("请选择输出目录");
                return;
            }
            
            // Process all files
            var files = GetExcelFilesSafely();
            if (files == null || files.Count == 0)
            {
                MessageBox.Show("没有可处理的Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                // 显示进度条
                progressBar.Visible = true;
                btnStart.Enabled = false;
                progressBar.Maximum = files.Count * 100; // 每个文件100单位进度
                progressBar.Value = 0;

                // 异步执行处理
                await Task.Run(() => ProcessFiles(files, outputDirectory));

                MessageBox.Show("处理完成");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"处理过程中出现错误: {ex.Message}\n详细信息: {ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏进度条
                progressBar.Visible = false;
                btnStart.Enabled = true;
            }
        }

        private void ProcessFiles(List<ExcelFile> files, string outputDirectory)
        {
            int totalFiles = files.Count;
            int processedFiles = 0;

            foreach (var file in files)
            {
                try
                {
                    file.SplitSheetsToFiles(outputDirectory);
                    
                    // 更新进度
                    processedFiles++;
                    int progress = (int)((processedFiles / (double)totalFiles) * 100);
                    this.Invoke((MethodInvoker)delegate {
                        if (progressBar.Value + 100 <= progressBar.Maximum)
                        {
                            progressBar.Value += 100;
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show($"处理文件 {file.FileName} 时出错: {ex.Message}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                }
            }
        }
    }
}