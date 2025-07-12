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
    internal class ExcelFile
    {
        private   string fileName = null; //文件名
        private IWorkbook workbook;


        public ExcelFile(string fileName)
        {
            this.fileName = fileName;
        }

        public bool OpenExcel() 
        {
            if (workbook != null) {
                return true;
            }
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    workbook = Path.GetExtension(fileName) switch
                    {
                        ".xls" => new HSSFWorkbook(fs),
                        ".xlsx" => new XSSFWorkbook(fs),
                        _ => throw new NotSupportedException("不支持的文件格式")
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
    }
    }
