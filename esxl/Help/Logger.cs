using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esxl.Help
{
    internal class Logger 
    {

        private static RichTextBox richTextBox;
        public static void Init(RichTextBox richTextBox)
        {
            Logger.richTextBox = richTextBox;
        }
        public static void Log(string message)
        { 
            message=$"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            //多线程访问RichTextBox
            if (richTextBox.InvokeRequired)
            {
                richTextBox.BeginInvoke(new Action(() =>
                {
                    richTextBox.AppendText(message + Environment.NewLine);
                    // 定位光标到末尾并滚动
                    richTextBox.SelectionStart = richTextBox.Text.Length;
                    richTextBox.ScrollToCaret(); // 关键滚动方法[1,3,4](@ref)
                }));
                return;
            }
            richTextBox.AppendText(message + Environment.NewLine);
            // 定位光标到末尾并滚动
            richTextBox.SelectionStart = richTextBox.Text.Length;
            richTextBox.ScrollToCaret(); // 关键滚动方法[1,3,4](@ref)

        }
    }
}
