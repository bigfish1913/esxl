using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    public class ExcelFile
    {
        private string fileName = string.Empty;
        private string extName = string.Empty;

        private IWorkbook? workbook;

        public required string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                extName = System.IO.Path.GetExtension(value)?.ToLower() ?? string.Empty;
            }
        }

        public ExcelFile()
        {
        }

        public ExcelFile(string fileName)
        {
            FileName = fileName; // 使用属性设置，确保extName也会被设置
        }

        public bool OpenExcel()
        {
            if (workbook != null)
            {
                return true;
            }
            try
            {
                using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    workbook = extName switch
                    {
                        ".xls" => new HSSFWorkbook(fs),
                        ".xlsx" => new XSSFWorkbook(fs),
                        _ => throw new NotSupportedException($"不支持的文件格式: {extName}")
                    };
                }
                return workbook != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"打开Excel文件失败: {ex.Message}");
                return false;
            }
        }

        public List<string> GetSheetList()
        {
            if (workbook == null)
                return new List<string>();

            var sheetCount = workbook.NumberOfSheets;
            List<string> list = new List<string>();
            for (int i = 0; i < sheetCount; i++)
            {
                list.Add(workbook.GetSheetName(i));
            }
            return list;
        }

        public Dictionary<string, List<IRow>> GroupDataByColumn(int groupColumnIndex, string sheetName)
        {
            if (workbook == null)
                return new Dictionary<string, List<IRow>>();

            ISheet sheet = workbook.GetSheet(sheetName);

            // 按分组列构建字典（Key: 分组值, Value: 行数据）
            var groups = new Dictionary<string, List<IRow>>();
            for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++) // 跳过标题行
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row == null) continue;

                ICell groupCell = row.GetCell(groupColumnIndex);
                string groupKey = groupCell?.ToString() ?? "UNKNOWN";

                if (!groups.ContainsKey(groupKey))
                    groups[groupKey] = new List<IRow>();
                groups[groupKey].Add(row);
            }
            return groups;
        }

        public void ExportGroupData(string sheetName, string outPutDir, Dictionary<string, List<IRow>> groups)
        {
            if (workbook == null)
                return;

            ISheet sheet = workbook.GetSheet(sheetName);

            // 为每个分组创建新工作簿并保存
            foreach (var group in groups)
            {
                IWorkbook groupWorkbook = new XSSFWorkbook();
                ISheet groupSheet = groupWorkbook.CreateSheet(group.Key);
                // 复制标题行（假设第一行为标题）
                IRow headerRow = sheet.GetRow(0);
                IRow newHeader = groupSheet.CreateRow(0);
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    newHeader.CreateCell(i).SetCellValue(headerRow.GetCell(i).ToString());
                }
                // 填充分组数据
                int dataRowIndex = 1;
                foreach (IRow row in group.Value)
                {
                    IRow newRow = groupSheet.CreateRow(dataRowIndex++);
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        newRow.CreateCell(i).SetCellValue(row.GetCell(i)?.ToString() ?? "");
                    }
                }

                // 保存分组文件
                string outputPath = Path.Combine(outPutDir, $"{group.Key}.xlsx");
                using (var outFs = new FileStream(outputPath, FileMode.Create))
                {
                    groupWorkbook.Write(outFs);
                }
            }
        }

        public void SplitSheetsToFiles(string outputDir)
        {
            if (string.IsNullOrEmpty(FileName) || workbook == null)
                return;

            // 确保输出目录存在
            Directory.CreateDirectory(outputDir);

            using FileStream fs = new(this.FileName, FileMode.Open, FileAccess.Read);
            // 根据文件扩展名选择工作簿类型
            IWorkbook sourceWorkbook = this.extName == ".xlsx"
                ? new XSSFWorkbook(fs)
                : new HSSFWorkbook(fs);

            // 遍历每个 Sheet
            for (int i = 0; i < sourceWorkbook.NumberOfSheets; i++)
            {
                ISheet sourceSheet = sourceWorkbook.GetSheetAt(i);
                string sheetName = sourceSheet.SheetName;

                // 创建新工作簿（仅含当前 Sheet）
                IWorkbook newWorkbook = sourceWorkbook is HSSFWorkbook
                    ? new HSSFWorkbook()
                    : new XSSFWorkbook();
                ISheet newSheet = newWorkbook.CreateSheet(sheetName);

                // 复制列宽
                for (int col = 0; col < sourceSheet.GetRow(0).LastCellNum; col++)
                {
                    newSheet.SetColumnWidth(col, sourceSheet.GetColumnWidth(col));
                }

                // 逐行复制数据及样式
                for (int rowIdx = 0; rowIdx <= sourceSheet.LastRowNum; rowIdx++)
                {
                    IRow sourceRow = sourceSheet.GetRow(rowIdx);
                    if (sourceRow == null) continue;

                    IRow newRow = newSheet.CreateRow(rowIdx);
                    newRow.Height = sourceRow.Height;

                    // 复制单元格
                    for (int cellIdx = 0; cellIdx < sourceRow.LastCellNum; cellIdx++)
                    {
                        ICell sourceCell = sourceRow.GetCell(cellIdx);
                        if (sourceCell == null) continue;

                        ICell newCell = newRow.CreateCell(cellIdx);

                        // 创建新的样式并复制        
                        ICellStyle newStyle = newWorkbook.CreateCellStyle();
                        newStyle.CloneStyleFrom(sourceCell.CellStyle);
                        newCell.CellStyle = newStyle;

                        // 根据数据类型赋值
                        switch (sourceCell.CellType)
                        {
                            case CellType.String:
                                newCell.SetCellValue(sourceCell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                newCell.SetCellValue(sourceCell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                newCell.SetCellValue(sourceCell.BooleanCellValue);
                                break;
                            case CellType.Formula:
                                newCell.SetCellFormula(sourceCell.CellFormula);
                                break;
                            default:
                                newCell.SetCellValue(string.Empty);
                                break;
                        }
                    }
                }

                // 保存新文件
                string outputPath = Path.Combine(outputDir, $"{Path.GetFileNameWithoutExtension(FileName)}_{sheetName}{extName}");
                using (FileStream outFs = new FileStream(outputPath, FileMode.Create))
                {
                    newWorkbook.Write(outFs);
                }
                newWorkbook.Close();
            }
        }

        /// <summary>
        /// 将单个工作表导出为独立Excel文件
        /// </summary>
        /// <param name="sheetName">要导出的工作表名称</param>
        /// <param name="outputPath">输出文件路径</param>
        public void ExportSingleSheet(string sheetName, string outputPath)
        {
            if (workbook == null)
                return;

            ISheet sourceSheet = workbook.GetSheet(sheetName);
            if (sourceSheet == null)
                return;

            // 创建新工作簿
            IWorkbook newWorkbook = workbook is XSSFWorkbook 
                ? new XSSFWorkbook() 
                : new HSSFWorkbook();
            ISheet newSheet = newWorkbook.CreateSheet(sheetName);

            // 复制列宽
            for (int col = 0; col < sourceSheet.GetRow(0).LastCellNum; col++)
            {
                newSheet.SetColumnWidth(col, sourceSheet.GetColumnWidth(col));
            }

            // 逐行复制数据及样式
            for (int rowIdx = 0; rowIdx <= sourceSheet.LastRowNum; rowIdx++)
            {
                IRow sourceRow = sourceSheet.GetRow(rowIdx);
                if (sourceRow == null) continue;

                IRow newRow = newSheet.CreateRow(rowIdx);
                newRow.Height = sourceRow.Height;

                // 复制单元格
                for (int cellIdx = 0; cellIdx < sourceRow.LastCellNum; cellIdx++)
                {
                    ICell sourceCell = sourceRow.GetCell(cellIdx);
                    if (sourceCell == null) continue;

                    ICell newCell = newRow.CreateCell(cellIdx);

                    // 创建新的样式并复制        
                    ICellStyle newStyle = newWorkbook.CreateCellStyle();
                    newStyle.CloneStyleFrom(sourceCell.CellStyle);
                    newCell.CellStyle = newStyle;

                    // 根据数据类型赋值
                    switch (sourceCell.CellType)
                    {
                        case CellType.String:
                            newCell.SetCellValue(sourceCell.StringCellValue);
                            break;
                        case CellType.Numeric:
                            newCell.SetCellValue(sourceCell.NumericCellValue);
                            break;
                        case CellType.Boolean:
                            newCell.SetCellValue(sourceCell.BooleanCellValue);
                            break;
                        case CellType.Formula:
                            newCell.SetCellFormula(sourceCell.CellFormula);
                            break;
                        default:
                            newCell.SetCellValue(string.Empty);
                            break;
                    }
                }
            }

            // 保存文件
            using (FileStream outFs = new FileStream(outputPath, FileMode.Create))
            {
                newWorkbook.Write(outFs);
            }
        }

        /// <summary>
        /// 获取工作表指定范围的数据
        /// </summary>
        /// <param name="sheetName">工作表名称</param>
        /// <param name="startRow">起始行索引</param>
        /// <param name="endRow">结束行索引</param>
        /// <returns>单元格数据二维数组</returns>
        public object[,] GetSheetDataRange(string sheetName, int startRow, int endRow)
        {
            if (workbook == null)
                return new object[0, 0];

            ISheet sheet = workbook.GetSheet(sheetName);
            if (sheet == null)
                return new object[0, 0];

            // 确保行范围有效
            startRow = Math.Max(0, startRow);
            endRow = Math.Min(sheet.LastRowNum, endRow);
            int rowCount = endRow - startRow + 1;

            // 获取最大列数
            int maxColCount = 0;
            for (int i = startRow; i <= endRow; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row != null)
                {
                    maxColCount = Math.Max(maxColCount, row.LastCellNum);
                }
            }

            // 填充数据
            object[,] data = new object[rowCount, maxColCount];
            for (int rowIdx = startRow; rowIdx <= endRow; rowIdx++)
            {
                IRow row = sheet.GetRow(rowIdx);
                if (row == null) continue;

                for (int colIdx = 0; colIdx < row.LastCellNum; colIdx++)
                {
                    ICell cell = row.GetCell(colIdx);
                    data[rowIdx - startRow, colIdx] = cell?.ToString() ?? string.Empty;
                }
            }

            return data;
        }

        /// <summary>
        /// 在工作表指定位置插入数据
        /// </summary>
        /// <param name="sheetName">工作表名称</param>
        /// <param name="data">要插入的数据</param>
        /// <param name="startRow">起始行索引</param>
        /// <param name="startCol">起始列索引</param>
        public void InsertDataIntoSheet(string sheetName, object[,] data, int startRow, int startCol)
        {
            if (workbook == null)
                return;

            ISheet sheet = workbook.GetSheet(sheetName);
            if (sheet == null)
                return;

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);

            // 插入数据
            for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                IRow row = sheet.GetRow(startRow + rowIdx) ?? sheet.CreateRow(startRow + rowIdx);

                for (int colIdx = 0; colIdx < colCount; colIdx++)
                {
                    ICell cell = row.GetCell(startCol + colIdx) ?? row.CreateCell(startCol + colIdx);
                    
                    // 根据数据类型设置单元格值
                    object value = data[rowIdx, colIdx];
                    if (value is string stringValue)
                    {
                        cell.SetCellValue(stringValue);
                    }
                    else if (value is double doubleValue)
                    {
                        cell.SetCellValue(doubleValue);
                    }
                    else if (value is bool boolValue)
                    {
                        cell.SetCellValue(boolValue);
                    }
                    else if (value is DateTime dateValue)
                    {
                        cell.SetCellValue(dateValue);
                    }
                    else
                    {
                        cell.SetCellValue(value?.ToString() ?? string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 关闭工作簿并释放资源
        /// </summary>
        public void Close()
        {
            if (workbook != null)
            {
                workbook.Close();
                workbook = null;
            }
        }
    }
}