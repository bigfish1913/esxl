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
    public partial class SplitFrm : Form
    {
        public SplitFrm()
        {
            InitializeComponent();
        }

        private void SplitFrm_Load(object sender, EventArgs e)
        {
            this.Text = "Sheet拆分保存";
        }
    }
}
