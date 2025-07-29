using esxl.Help;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // We no longer need to select a single file in MainFrm since we're handling multiple files in Main
            MessageBox.Show("请在主界面添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGroupBy_Click(object sender, EventArgs e)
        {
            // Check if we have any files
            if (ExcelContext.GetAllFiles().Count == 0)
            {
                MessageBox.Show("请先添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var groupByFrm = new GroupByFrm();
            groupByFrm.ShowDialog(this);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            // 自动更新功能已移至Main.cs中实现
        }

        private void btnSheetSave_Click(object sender, EventArgs e)
        {
            // Check if we have any files
            if (ExcelContext.GetAllFiles().Count == 0)
            {
                MessageBox.Show("请先添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SplitFrm frm = new();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// 发布应用程序到Gitee
        /// </summary>
        private async void PublishToGitee()
        {
            try
            {
                // 显示进度条窗体
                ProcessFrm processFrm = new ProcessFrm();
                processFrm.Text = "正在发布到Gitee...";
                processFrm.Show();
                processFrm.Refresh();

                // 执行发布脚本
                await Task.Run(() =>
                {
                    try
                    {
                        // 确保publish_gitee.bat文件存在
                        string scriptPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "publish_gitee.bat");
                        
                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = scriptPath,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true
                        };
                        
                        using (Process process = Process.Start(startInfo))
                        {
                            // 等待脚本执行完成
                            process.WaitForExit();
                            
                            // 检查执行结果
                            if (process.ExitCode != 0)
                            {
                                string error = process.StandardError.ReadToEnd();
                                throw new Exception($"发布脚本执行失败: {error}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"执行发布脚本时出错: {ex.Message}");
                    }
                });

                processFrm.Close();

                MessageBox.Show("发布完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发布失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 发布按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要发布到Gitee吗？", "确认发布", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PublishToGitee();
            }
        }
    }
}
