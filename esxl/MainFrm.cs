namespace esxl
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            var splitFrm = new SplitFrm();
            splitFrm.ShowDialog();
        }
    }
}
