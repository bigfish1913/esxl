using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class ExcelContext
    {
        private static List<ExcelFile> ContextFileList = new List<ExcelFile>();

        public static void AddFile(ExcelFile file)
        {
            ContextFileList.Add(file);
        }
        
        public static void Clear()
        {
            ContextFileList.Clear();
        }
        
        public static void RemoveFile(ExcelFile file)
        {
            ContextFileList.Remove(file);
        }
        
        public static ExcelFile? GetFile(string fileName)
        {
            return ContextFileList.FirstOrDefault(x => x.FileName == fileName);
        }
        
        public static List<ExcelFile> GetAllFiles()
        {
            return ContextFileList;
        }
    }
}
