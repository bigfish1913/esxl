using esxl.Help;
using Newtonsoft.Json;
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
    public partial class Main : Form
    {
        // 根节点
        private TreeNode rootFileNode = null!;
        // 当前项目文件路径
        private string currentProjectFile = string.Empty;
        // 文件系统监控器
        private FileSystemWatcher fileSystemWatcher = null!;
        // 防止TreeView事件循环触发的标志
        private bool isUpdatingNodes = false;

        public Main()
        {
            InitializeComponent();
            Logger.Init(richTextBox1);
            ExcelContext.Clear(); // Clear any existing context
            
            // 初始化根节点
            rootFileNode = new TreeNode("Excel文件列表");
            fileTree.Nodes.Add(rootFileNode);
            fileTree.NodeMouseHover += FileTree_NodeMouseHover;
            
            // 初始化文件系统监控器
            InitializeFileSystemWatcher();
        }

        // 初始化文件系统监控器
        private void InitializeFileSystemWatcher()
        {
            fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite;
            fileSystemWatcher.Changed += OnFileSystemChanged;
            fileSystemWatcher.Created += OnFileSystemChanged;
            fileSystemWatcher.Deleted += OnFileSystemChanged;
            fileSystemWatcher.Renamed += OnFileSystemRenamed;
            fileSystemWatcher.IncludeSubdirectories = false;
            // 不设置路径且不启用事件，避免启动时出现"Error reading the directory"错误
            // fileSystemWatcher.EnableRaisingEvents = true;
        }

        // 文件系统变更事件处理
        private void OnFileSystemChanged(object sender, FileSystemEventArgs e)
        {
            // 在UI线程上更新文件状态
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateFileNodes()));
            }
            else
            {
                UpdateFileNodes();
            }
        }

        // 文件重命名事件处理
        private void OnFileSystemRenamed(object sender, RenamedEventArgs e)
        {
            // 在UI线程上更新文件状态
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateFileNodes()));
            }
            else
            {
                UpdateFileNodes();
            }
        }

        // 更新文件节点状态
        private void UpdateFileNodes()
        {
            // 遍历所有文件节点，检查文件是否存在并更新显示状态
            foreach (TreeNode node in rootFileNode.Nodes)
            {
                if (node.Tag is ExcelFile excelFile)
                {
                    // 检查文件是否存在，更新节点颜色
                    if (File.Exists(excelFile.FileName))
                    {
                        node.ForeColor = Color.Black; // 文件存在，显示为黑色
                    }
                    else
                    {
                        node.ForeColor = Color.Gray; // 文件不存在，显示为灰色
                    }
                }
            }
        }

        // 鼠标悬停事件处理
        private void FileTree_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node.Tag is ExcelFile excelFile)
            {
                // 设置工具提示显示文件详细信息
                toolTip1.SetToolTip(fileTree, $"文件路径: {excelFile.FileName}\n文件大小: {GetFileSize(excelFile.FileName)}");
            }
            else if (e.Node.Parent != null && e.Node.Parent.Tag is ExcelFile parentExcelFile)
            {
                // Sheet节点显示其所属文件信息
                toolTip1.SetToolTip(fileTree, $"Sheet名称: {e.Node.Text}\n所属文件: {parentExcelFile.FileName}");
            }
            else
            {
                // 清除工具提示
                toolTip1.SetToolTip(fileTree, "");
            }
        }

        // 获取文件大小的辅助方法
        private string GetFileSize(string filePath)
        {
            try
            {
                var fileInfo = new System.IO.FileInfo(filePath);
                long size = fileInfo.Length;
                
                // 格式化文件大小显示
                if (size < 1024)
                    return $"{size} B";
                else if (size < 1024 * 1024)
                    return $"{size / 1024.0:F2} KB";
                else if (size < 1024 * 1024 * 1024)
                    return $"{size / (1024.0 * 1024.0):F2} MB";
                else
                    return $"{size / (1024.0 * 1024.0 * 1024.0):F2} GB";
            }
            catch
            {
                return "未知大小";
            }
        }

        /// <summary>
        /// 窗体加载事件处理方法
        /// 在窗体首次加载时进行初始化操作
        /// </summary>
        /// <param name="sender">事件触发对象</param>
        /// <param name="e">事件参数</param>
        private void Main_Load(object sender, EventArgs e)
        {
            // 移除定时器相关代码，使用FileSystemWatcher替代
        }

        /// <summary>
        /// 定时检查文件存在性（已废弃，使用FileSystemWatcher替代）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileExistenceTimer_Tick(object sender, EventArgs e)
        {
            // 此方法已废弃，保留仅作参考
            // 遍历所有文件节点，检查文件是否存在并更新显示状态
            foreach (TreeNode node in rootFileNode.Nodes)
            {
                if (node.Tag is ExcelFile excelFile)
                {
                    // 检查文件是否存在，更新节点颜色
                    if (File.Exists(excelFile.FileName))
                    {
                        node.ForeColor = Color.Black; // 文件存在，显示为黑色
                    }
                    else
                    {
                        node.ForeColor = Color.Gray; // 文件不存在，显示为灰色
                    }
                }
            }
        }

        /// <summary>
        /// "添加"按钮点击事件处理方法
        /// 用于添加新的Excel文件到项目中
        /// </summary>
        /// <param name="sender">事件触发对象</param>
        /// <param name="e">事件参数</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFilesForm addFilesForm = new AddFilesForm();
            if (addFilesForm.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in addFilesForm.SelectedFiles)
                {
                    AddExcelFile(filePath);
                }
            }
        }

        private void btnMergeFiles_Click(object sender, EventArgs e)
        {
            mergeFilesToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// 添加Excel文件到工作空间
        /// </summary>
        /// <param name="fileName">Excel文件路径</param>
        private void AddExcelFile(string fileName)
        {
            // Check if file is already added
            if (string.IsNullOrEmpty(fileName) || rootFileNode.Nodes.Cast<TreeNode>().Any(n => n.Text == System.IO.Path.GetFileName(fileName)))
            {
                return; // Skip if already added or fileName is null/empty
            }

            ExcelFile excelFile = new ExcelFile()
            {
                FileName = fileName
            };
            
            // 创建文件节点
            TreeNode node = new TreeNode(System.IO.Path.GetFileName(fileName))
            {
                Tag = excelFile // Store reference to ExcelFile
            };

            // 检查文件是否存在，如果不存在则显示为灰色
            if (!File.Exists(fileName))
            {
                node.ForeColor = Color.Gray;
            }

            if (excelFile.OpenExcel())
            {
                ExcelContext.AddFile(excelFile);

                // Add sheet nodes
                var sheets = excelFile.GetSheetList();
                foreach (string sheet in sheets)
                {
                    TreeNode sheetNode = new TreeNode(sheet);
                    node.Nodes.Add(sheetNode);
                }

                rootFileNode.Nodes.Add(node);
                rootFileNode.Expand(); // 展开根节点显示新添加的文件
                Logger.Log($"已添加文件: {fileName}");
                
                // 显示文件信息
                DisplayFileInfo(excelFile);
            }
            else
            {
                Logger.Log($"打开文件失败: {fileName}");
                MessageBox.Show($"无法打开文件: {fileName}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 显示文件信息
        /// </summary>
        /// <param name="excelFile">Excel文件对象</param>
        private void DisplayFileInfo(ExcelFile excelFile)
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"文件路径: {excelFile.FileName}");
            info.AppendLine($"文件大小: {GetFileSize(excelFile.FileName)}");
            info.AppendLine($"添加时间: {DateTime.Now}");
            
            var sheets = excelFile.GetSheetList();
            info.AppendLine($"工作表数量: {sheets.Count}");
            info.AppendLine("工作表列表:");
            foreach (string sheet in sheets)
            {
                info.AppendLine($"  - {sheet}");
            }
            
            fileInfoTextBox.Text = info.ToString();
        }

        /// <summary>
        /// "移除"按钮点击事件处理方法
        /// 用于从项目中移除选中的Excel文件
        /// </summary>
        /// <param name="sender">事件触发对象</param>
        /// <param name="e">事件参数</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (fileTree.SelectedNode == null || fileTree.SelectedNode == rootFileNode)
            {
                MessageBox.Show("请选择要移除的文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TreeNode selectedNode = fileTree.SelectedNode;
            
            // If a sheet is selected, select its parent file node
            if (selectedNode.Level == 2) 
            {
                selectedNode = selectedNode.Parent;
            }
            
            // At this point, selectedNode should be a file node (level 1)
            if (selectedNode.Level == 1 && selectedNode.Tag is ExcelFile excelFile)
            {
                ExcelContext.RemoveFile(excelFile);
                rootFileNode.Nodes.Remove(selectedNode);
                Logger.Log($"已移除文件: {excelFile.FileName}");
            }
        }

        /// <summary>
        /// 新建项目（清空当前工作区）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 如果当前有文件，提示用户保存
            if (ExcelContext.GetAllFiles().Count > 0)
            {
                var result = MessageBox.Show("是否保存当前项目?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        SaveProject();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            
            // 清空工作区
            ClearWorkspace();
        }

        /// <summary>
        /// 打开项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 如果当前有文件，提示用户保存
            if (ExcelContext.GetAllFiles().Count > 0)
            {
                var result = MessageBox.Show("是否保存当前项目?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        SaveProject();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            
            LoadProject();
        }

        /// <summary>
        /// 保存项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        /// <summary>
        /// 另存为项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 如果当前有文件，提示用户保存
            if (ExcelContext.GetAllFiles().Count > 0)
            {
                var result = MessageBox.Show("是否保存当前项目?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        SaveProject();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            
            this.Close();
        }

        /// <summary>
        /// 按分组拆分文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查是否有文件
            if (ExcelContext.GetAllFiles().Count == 0)
            {
                MessageBox.Show("请先添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var groupByFrm = new GroupByFrm();
            groupByFrm.ShowDialog(this);
        }

        /// <summary>
        /// 按Sheet保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sheetSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查是否有文件
            if (ExcelContext.GetAllFiles().Count == 0)
            {
                MessageBox.Show("请先添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SplitFrm frm = new();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// 合并Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mergeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查是否有文件
            if (ExcelContext.GetAllFiles().Count == 0)
            {
                MessageBox.Show("请先添加Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MergeFilesForm frm = new MergeFilesForm();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// 保存当前工作区到项目文件
        /// </summary>
        private void SaveProject()
        {
            // 如果当前没有项目文件，则调用另存为功能
            if (string.IsNullOrEmpty(currentProjectFile))
            {
                SaveProjectAs();
                return;
            }

            try
            {
                // 创建项目信息对象
                var projectInfo = new ProjectInfo
                {
                    ProjectName = string.IsNullOrEmpty(currentProjectFile) ? "未命名项目" : Path.GetFileNameWithoutExtension(currentProjectFile),
                    LastModifiedDate = DateTime.Now,
                    ExcelFilePaths = ExcelContext.GetAllFiles().Select(f => f.FileName).ToList()
                };

                // 序列化为JSON并保存到文件
                string json = JsonConvert.SerializeObject(projectInfo, Formatting.Indented);
                File.WriteAllText(currentProjectFile, json, Encoding.UTF8);
                
                Logger.Log($"项目已保存到: {currentProjectFile}");
                MessageBox.Show("项目保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.Log($"保存项目失败: {ex.Message}");
                MessageBox.Show($"保存项目失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 另存为项目文件
        /// </summary>
        private void SaveProjectAs()
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Title = "保存项目文件",
                Filter = "项目文件|*.esxlproj",
                DefaultExt = "esxlproj"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                currentProjectFile = saveDialog.FileName;
                SaveProject();
            }
        }

        /// <summary>
        /// 加载项目文件
        /// </summary>
        private void LoadProject()
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Title = "打开项目文件",
                Filter = "项目文件|*.esxlproj"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 清空当前工作区
                    ClearWorkspace();

                    // 读取并反序列化项目文件
                    string json = File.ReadAllText(openDialog.FileName, Encoding.UTF8);
                    ProjectInfo projectInfo = JsonConvert.DeserializeObject<ProjectInfo>(json);

                    if (projectInfo != null)
                    {
                        currentProjectFile = openDialog.FileName;

                        // 加载Excel文件
                        foreach (string filePath in projectInfo.ExcelFilePaths)
                        {
                            if (string.IsNullOrEmpty(filePath))
                                continue;
                                
                            if (File.Exists(filePath))
                            {
                                AddExcelFile(filePath);
                            }
                            else
                            {
                                Logger.Log($"文件不存在: {filePath}");
                                MessageBox.Show($"文件不存在: {filePath}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        Logger.Log($"项目加载成功: {projectInfo.ProjectName}");
                        MessageBox.Show("项目加载成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"加载项目失败: {ex.Message}");
                    MessageBox.Show($"加载项目失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 清空当前工作区
        /// </summary>
        private void ClearWorkspace()
        {
            ExcelContext.Clear();
            rootFileNode.Nodes.Clear();
            currentProjectFile = string.Empty;
            Logger.Log("工作区已清空");
        }

        private void UpdateChildNodes(TreeNode node, bool isChecked)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.Checked = isChecked;
                UpdateChildNodes(childNode, isChecked);
            }
        }

        private void UpdateParentNode(TreeNode node)
        {
            if (node.Parent == null) return;

            bool allChecked = node.Parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
            bool anyChecked = node.Parent.Nodes.Cast<TreeNode>().Any(n => n.Checked);

            node.Parent.Checked = allChecked;

            if (allChecked || anyChecked)
            {
                UpdateParentNode(node.Parent);
            }
        }

        private void fileTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 防止事件循环触发
            if (isUpdatingNodes) return;

            try
            {
                isUpdatingNodes = true;

                // 更新子节点的选中状态
                UpdateChildNodes(e.Node, e.Node.Checked);

                // 更新父节点的选中状态
                UpdateParentNode(e.Node);
            }
            finally
            {
                isUpdatingNodes = false;
            }
        }

        /// <summary>
        /// 文件树节点选中事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 切换到文件信息标签页
            tabControl1.SelectedTab = fileInfoTabPage;
            
            if (e.Node?.Tag is ExcelFile excelFile)
            {
                // 显示文件信息
                DisplayFileInfo(excelFile);
                
                // 预览数据（显示第一个工作表的数据）
                PreviewExcelData(excelFile);
            }
            else if (e.Node?.Parent != null && e.Node.Parent.Tag is ExcelFile parentExcelFile)
            {
                // 选中的是工作表节点，显示该工作表的数据
                // 切换到数据预览标签页
                tabControl1.SelectedTab = filePreviewTabPage;
                PreviewExcelData(parentExcelFile, e.Node.Text);
            }
        }

        /// <summary>
        /// 预览Excel数据
        /// </summary>
        /// <param name="excelFile">Excel文件对象</param>
        /// <param name="sheetName">工作表名称，默认为第一个工作表</param>
        private void PreviewExcelData(ExcelFile excelFile, string sheetName = null)
        {
            try
            {
                // 确保Excel文件已打开
                if (!excelFile.OpenExcel())
                {
                    Logger.Log($"无法打开Excel文件: {excelFile.FileName}");
                    return;
                }

                var sheets = excelFile.GetSheetList();
                if (sheets.Count == 0) return;

                // 如果未指定工作表名称，则使用第一个工作表
                if (string.IsNullOrEmpty(sheetName))
                {
                    sheetName = sheets[0];
                }

                // 获取工作表数据
                // 这里我们获取前50行数据用于预览
                object[,] data = excelFile.GetSheetDataRange(sheetName, 0, 49);
                
                if (data.GetLength(0) == 0)
                {
                    // 没有数据，显示提示信息
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = "提示";
                    col.Name = "提示";
                    dataGridView1.Columns.Add(col);
                    
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = $"工作表 '{sheetName}' 没有数据";
                    dataGridView1.Rows.Add(row);
                    return;
                }
                
                // 将数据转换为DataTable以便在DataGridView中显示
                DataTable dataTable = new DataTable();
                
                // 添加列（使用第一行作为列标题，如果有的话）
                int colCount = data.GetLength(1);
                int rowCount = data.GetLength(0);
                
                if (rowCount > 0)
                {
                    // 添加列标题
                    for (int i = 0; i < colCount; i++)
                    {
                        string columnName = (data[0, i]?.ToString() ?? "") != "" ? data[0, i].ToString() : $"列{i + 1}";
                        // 确保列名唯一
                        string finalColumnName = columnName;
                        int suffix = 1;
                        while (dataTable.Columns.Contains(finalColumnName))
                        {
                            finalColumnName = $"{columnName}_{suffix}";
                            suffix++;
                        }
                        dataTable.Columns.Add(finalColumnName);
                    }
                    
                    // 添加数据行（从第二行开始，如果第一行是标题）
                    int startRow = 1; // 假设第一行是标题
                    for (int rowIdx = startRow; rowIdx < rowCount; rowIdx++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int colIdx = 0; colIdx < Math.Min(colCount, dataTable.Columns.Count); colIdx++)
                        {
                            dataRow[colIdx] = data[rowIdx, colIdx]?.ToString() ?? "";
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // 没有数据行，只创建列结构
                    for (int i = 0; i < colCount; i++)
                    {
                        dataTable.Columns.Add($"列{i + 1}");
                    }
                }
                
                // 绑定数据到DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                Logger.Log($"预览数据失败: {ex.Message}");
                // 显示错误信息
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.HeaderText = "错误";
                col.Name = "错误";
                dataGridView1.Columns.Add(col);
                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = $"预览数据失败: {ex.Message}";
                dataGridView1.Rows.Add(row);
            }
        }

        /// <summary>
        /// 打开文件所在位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 获取选中的节点
            TreeNode selectedNode = fileTree.SelectedNode;
            if (selectedNode == null) return;

            // 如果选中的是Sheet节点，则获取其父节点（文件节点）
            if (selectedNode.Level == 2)
            {
                selectedNode = selectedNode.Parent;
            }

            // 确保选中的是文件节点
            if (selectedNode?.Tag is ExcelFile excelFile)
            {
                string filePath = excelFile.FileName;
                if (File.Exists(filePath))
                {
                    // 使用系统资源管理器打开文件所在位置并选中文件
                    System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
                }
                else
                {
                    // 文件不存在，只打开所在文件夹
                    string folderPath = Path.GetDirectoryName(filePath);
                    if (Directory.Exists(folderPath))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", folderPath);
                    }
                    else
                    {
                        MessageBox.Show("文件所在目录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}