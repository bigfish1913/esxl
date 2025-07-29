using esxl.Help;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
    public partial class MergeFilesForm : Form
    {
        public MergeFilesForm()
        {
            InitializeComponent();
        }

        private void MergeFilesForm_Load(object sender, EventArgs e)
        {
            // 加载所有Excel文件到列表中
            foreach (ExcelFile file in ExcelContext.GetAllFiles())
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(file.FileName));
                item.SubItems.Add(GetFileSize(file.FileName));
                item.SubItems.Add(file.GetSheetList().Count.ToString());
                item.Tag = file;
                fileListView.Items.Add(item);
            }

            // 设置默认输出路径
            outputTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private string GetFileSize(string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
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

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileListView.Items)
            {
                item.Checked = selectAllCheckBox.Checked;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    outputTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            // 检查是否选择了文件
            var selectedItems = fileListView.CheckedItems.Cast<ListViewItem>().ToList();
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("请至少选择一个文件进行合并", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 检查输出目录
            if (string.IsNullOrEmpty(outputTextBox.Text))
            {
                MessageBox.Show("请选择输出目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 检查输出目录是否存在
            if (!Directory.Exists(outputTextBox.Text))
            {
                try
                {
                    Directory.CreateDirectory(outputTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"无法创建输出目录: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 执行合并操作
            MergeSelectedFiles(selectedItems);
        }

        private async void MergeSelectedFiles(List<ListViewItem> selectedItems)
        {
            try
            {
                // 显示进度条
                progressBar.Visible = true;
                mergeButton.Enabled = false;
                progressBar.Maximum = selectedItems.Count * 100; // 每个文件100单位进度
                progressBar.Value = 0;

                // 收集所有文件和工作表
                List<MergeFileInfo> mergeFiles = new List<MergeFileInfo>();
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.Tag is ExcelFile excelFile)
                    {
                        mergeFiles.Add(new MergeFileInfo
                        {
                            File = excelFile,
                            FileName = excelFile.FileName,
                            SheetNames = excelFile.GetSheetList()
                        });
                    }
                }

                // 检查是否有相同名称的工作表
                var allSheetNames = mergeFiles.SelectMany(f => f.SheetNames).Distinct().ToList();
                var duplicateSheetNames = mergeFiles
                    .SelectMany(f => f.SheetNames)
                    .GroupBy(name => name)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                // 如果有重复的工作表名称，提示用户
                if (duplicateSheetNames.Any())
                {
                    var result = MessageBox.Show(
                        $"检测到以下工作表名称在多个文件中存在:\n{string.Join(", ", duplicateSheetNames)}\n\n是否继续合并？",
                        "工作表名称冲突",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                // 异步执行合并操作
                await Task.Run(() => PerformMerge(mergeFiles));

                MessageBox.Show("文件合并完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"合并过程中出现错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 隐藏进度条
                progressBar.Visible = false;
                mergeButton.Enabled = true;
            }
        }

        private void PerformMerge(List<MergeFileInfo> mergeFiles)
        {
            // 创建新的工作簿
            IWorkbook mergedWorkbook = new XSSFWorkbook(); // 默认创建.xlsx格式

            int totalFiles = mergeFiles.Count;
            int processedFiles = 0;

            foreach (var mergeFile in mergeFiles)
            {
                try
                {
                    // 打开文件
                    mergeFile.File.OpenExcel();
                    var workbook = GetWorkbookFromFile(mergeFile.FileName);

                    if (workbook != null)
                    {
                        // 复制每个工作表
                        for (int i = 0; i < workbook.NumberOfSheets; i++)
                        {
                            ISheet sourceSheet = workbook.GetSheetAt(i);
                            string originalSheetName = sourceSheet.SheetName;

                            // 处理重名工作表
                            string newSheetName = originalSheetName;
                            int suffix = 1;
                            while (mergedWorkbook.GetSheet(newSheetName) != null)
                            {
                                newSheetName = $"{originalSheetName}_{suffix}";
                                suffix++;
                            }

                            // 创建新工作表
                            ISheet targetSheet = mergedWorkbook.CreateSheet(newSheetName);

                            // 复制列宽
                            if (sourceSheet.GetRow(0) != null)
                            {
                                for (int col = 0; col < sourceSheet.GetRow(0).LastCellNum; col++)
                                {
                                    targetSheet.SetColumnWidth(col, sourceSheet.GetColumnWidth(col));
                                }
                            }

                            // 逐行复制数据及样式
                            for (int rowIdx = 0; rowIdx <= sourceSheet.LastRowNum; rowIdx++)
                            {
                                IRow sourceRow = sourceSheet.GetRow(rowIdx);
                                if (sourceRow == null) continue;

                                IRow targetRow = targetSheet.CreateRow(rowIdx);
                                targetRow.Height = sourceRow.Height;

                                // 复制单元格
                                for (int cellIdx = 0; cellIdx < sourceRow.LastCellNum; cellIdx++)
                                {
                                    ICell sourceCell = sourceRow.GetCell(cellIdx);
                                    if (sourceCell == null) continue;

                                    ICell targetCell = targetRow.CreateCell(cellIdx);

                                    // 复制样式
                                    ICellStyle targetStyle = mergedWorkbook.CreateCellStyle();
                                    targetStyle.CloneStyleFrom(sourceCell.CellStyle);
                                    targetCell.CellStyle = targetStyle;

                                    // 根据数据类型赋值
                                    switch (sourceCell.CellType)
                                    {
                                        case CellType.String:
                                            targetCell.SetCellValue(sourceCell.StringCellValue);
                                            break;
                                        case CellType.Numeric:
                                            targetCell.SetCellValue(sourceCell.NumericCellValue);
                                            break;
                                        case CellType.Boolean:
                                            targetCell.SetCellValue(sourceCell.BooleanCellValue);
                                            break;
                                        case CellType.Formula:
                                            targetCell.SetCellFormula(sourceCell.CellFormula);
                                            break;
                                        default:
                                            targetCell.SetCellValue(string.Empty);
                                            break;
                                    }
                                }
                            }
                        }

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
                }
                catch (Exception ex)
                {
                    // 记录错误但继续处理其他文件
                    this.Invoke((MethodInvoker)delegate {
                        MessageBox.Show($"处理文件 {mergeFile.FileName} 时出错: {ex.Message}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    });
                }
            }

            // 保存合并后的文件
            string outputPath = Path.Combine(outputTextBox.Text, $"合并文件_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            try
            {
                using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    mergedWorkbook.Write(fs);
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate {
                    MessageBox.Show($"保存合并文件时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            finally
            {
                mergedWorkbook.Close();
            }
        }

        private IWorkbook GetWorkbookFromFile(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    string ext = Path.GetExtension(filePath)?.ToLower();
                    return ext switch
                    {
                        ".xls" => new HSSFWorkbook(fs),
                        ".xlsx" => new XSSFWorkbook(fs),
                        _ => null
                    };
                }
            }
            catch
            {
                return null;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class MergeFileInfo
    {
        public ExcelFile File { get; set; }
        public string FileName { get; set; }
        public List<string> SheetNames { get; set; }
    }
}