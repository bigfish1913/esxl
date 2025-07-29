using System;
using System.Collections.Generic;

namespace esxl.Help
{
    /// <summary>
    /// 项目信息类，用于保存和加载工作区信息
    /// </summary>
    public class ProjectInfo
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Excel文件路径列表
        /// </summary>
        public List<string> ExcelFilePaths { get; set; } = new List<string>();
    }
}