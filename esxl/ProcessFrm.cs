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
    public partial class ProcessFrm : Form
    {
        public ProcessFrm()
        {
            InitializeComponent();
        }

        private void ProcessFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void Process()
        {
            //进度条设置
            progressBar1.Minimum = 0;

        }
    }
}
