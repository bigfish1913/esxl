using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esxl
{
    public partial class AddFilesForm : Form
    {
        private List<string> selectedFiles = new List<string>();
        private bool isUpdatingNodes = false; // 防止递归更新导致的StackOverflow异常

        public List<string> SelectedFiles { get { return selectedFiles; } }

        public AddFilesForm()
        {
            InitializeComponent();
        }

        private void AddFilesForm_Load(object sender, EventArgs e)
        {
            // 设置默认选项为直接添加文件
            directAddRadioButton.Checked = true;
        }

        private void directAddRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        private void scanAddRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlsState();
        }

        private void UpdateControlsState()
        {
            // 根据选择的添加方式更新控件状态
            browseFileButton.Enabled = directAddRadioButton.Checked;
            browseFolderButton.Enabled = scanAddRadioButton.Checked;
            selectAllButton.Enabled = scanAddRadioButton.Checked && fileTreeView.Nodes.Count > 0;
            deselectAllButton.Enabled = scanAddRadioButton.Checked && fileTreeView.Nodes.Count > 0;
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "选择Excel文件",
                Filter = "Excel文件|*.xlsx;*.xlsm;*.xls",
                Multiselect = true
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                selectedFiles.Clear();
                selectedFiles.AddRange(dialog.FileNames);
                UpdateFileList();
                okButton.Enabled = selectedFiles.Count > 0;
            }
        }

        private void browseFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "选择要扫描的文件夹";

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderDialog.SelectedPath;
                directoryTextBox.Text = selectedDirectory;
                ScanDirectory(selectedDirectory);
                UpdateControlsState();
            }
        }

        private void ScanDirectory(string directory)
        {
            try
            {
                // 清空之前的扫描结果
                fileTreeView.Nodes.Clear();
                selectedFiles.Clear();

                // 创建根节点
                TreeNode rootNode = new TreeNode(directory);
                rootNode.Tag = directory;
                fileTreeView.Nodes.Add(rootNode);

                // 递归扫描目录
                ScanDirectoryRecursive(directory, rootNode);

                // 展开根节点
                rootNode.Expand();

                // 更新状态标签
                statusLabel.Text = $"找到 {CountFiles(fileTreeView.Nodes)} 个Excel文件";
                okButton.Enabled = false; // 初始时没有选择文件
            }
            catch (Exception ex)
            {
                MessageBox.Show($"扫描目录时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CountFiles(TreeNodeCollection nodes)
        {
            int count = 0;
            foreach (TreeNode node in nodes)
            {
                // 如果节点代表一个文件，则计数加1
                if (node.Tag is string path &&
                    !string.IsNullOrEmpty(path) &&
                    (path.ToLower().EndsWith(".xlsx") || path.ToLower().EndsWith(".xls") || path.ToLower().EndsWith(".xlsm")))
                {
                    count++;
                }

                // 递归处理子节点
                if (node.Nodes.Count > 0)
                {
                    count += CountFiles(node.Nodes);
                }
            }
            return count;
        }

        private void ScanDirectoryRecursive(string directory, TreeNode parentNode)
        {
            try
            {
                // 获取当前目录下的Excel文件
                string[] files = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(file => file.ToLower().EndsWith(".xlsx") || file.ToLower().EndsWith(".xls") || file.ToLower().EndsWith(".xlsm"))
                    .ToArray();

                foreach (string file in files)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                        fileNode.Tag = file;
                        parentNode.Nodes.Add(fileNode);
                    }
                }

                // 递归处理子目录
                string[] subDirectories = Directory.GetDirectories(directory);
                foreach (string subDir in subDirectories)
                {
                    if (!string.IsNullOrEmpty(subDir))
                    {
                        TreeNode dirNode = new TreeNode(Path.GetFileName(subDir));
                        dirNode.Tag = subDir;
                        parentNode.Nodes.Add(dirNode);
                        ScanDirectoryRecursive(subDir, dirNode);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 忽略没有权限访问的目录
                TreeNode errorNode = new TreeNode("[访问被拒绝]");
                errorNode.ForeColor = Color.Red;
                parentNode.Nodes.Add(errorNode);
            }
            catch (Exception ex)
            {
                // 添加错误节点
                TreeNode errorNode = new TreeNode($"[错误: {ex.Message}]");
                errorNode.ForeColor = Color.Red;
                parentNode.Nodes.Add(errorNode);
            }
        }

        private void fileTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 防止递归调用导致的StackOverflow异常
            if (isUpdatingNodes) return;

            isUpdatingNodes = true;
            try
            {
                // 处理节点选中状态变化
                TreeNode node = e.Node;
                UpdateChildNodes(node);
                UpdateParentNodes(node);
                UpdateSelectedFilesList();
            }
            finally
            {
                isUpdatingNodes = false;
            }
        }

        private void UpdateChildNodes(TreeNode node)
        {
            // 更新所有子节点的选中状态
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.Checked = node.Checked;
                UpdateChildNodes(childNode);
            }
        }

        private void UpdateParentNodes(TreeNode node)
        {
            // 更新父节点的选中状态
            if (node.Parent != null)
            {
                bool allChecked = node.Parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
                bool anyChecked = node.Parent.Nodes.Cast<TreeNode>().Any(n => n.Checked);

                if (allChecked)
                {
                    node.Parent.Checked = true;
                }
                else if (!anyChecked)
                {
                    node.Parent.Checked = false;
                }
                // 部分选中状态由TreeView控件自动处理

                // 递归更新祖父节点
                UpdateParentNodes(node.Parent);
            }
        }

        private void UpdateSelectedFilesList()
        {
            selectedFiles.Clear();
            CollectCheckedFiles(fileTreeView.Nodes);

            // 更新状态标签
            statusLabel.Text = $"已选择 {selectedFiles.Count} 个文件，共找到 {CountFiles(fileTreeView.Nodes)} 个Excel文件";
            okButton.Enabled = selectedFiles.Count > 0;
            
            // 更新文件列表框
            UpdateFileList();
        }

        private void CollectCheckedFiles(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // 如果节点代表一个文件且被选中，则添加到列表中
                if (node.Tag is string path &&
                    !string.IsNullOrEmpty(path) &&
                    (path.ToLower().EndsWith(".xlsx") || path.ToLower().EndsWith(".xls") || path.ToLower().EndsWith(".xlsm")) &&
                    node.Checked)
                {
                    selectedFiles.Add(path);
                }

                // 递归处理子节点
                if (node.Nodes.Count > 0)
                {
                    CollectCheckedFiles(node.Nodes);
                }
            }
        }

        private void UpdateFileList()
        {
            fileListBox.Items.Clear();
            foreach (string file in selectedFiles)
            {
                if (!string.IsNullOrEmpty(file))
                {
                    fileListBox.Items.Add(Path.GetFileName(file));
                }
            }
            statusLabel.Text = $"已选择 {selectedFiles.Count} 个文件";
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            if (isUpdatingNodes) return;

            isUpdatingNodes = true;
            try
            {
                foreach (TreeNode node in fileTreeView.Nodes)
                {
                    node.Checked = true;
                    UpdateChildNodes(node);
                }
                UpdateSelectedFilesList();
            }
            finally
            {
                isUpdatingNodes = false;
            }
        }

        private void deselectAllButton_Click(object sender, EventArgs e)
        {
            if (isUpdatingNodes) return;

            isUpdatingNodes = true;
            try
            {
                foreach (TreeNode node in fileTreeView.Nodes)
                {
                    node.Checked = false;
                    UpdateChildNodes(node);
                }
                UpdateSelectedFilesList();
            }
            finally
            {
                isUpdatingNodes = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count == 0)
            {
                MessageBox.Show("请至少选择一个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}