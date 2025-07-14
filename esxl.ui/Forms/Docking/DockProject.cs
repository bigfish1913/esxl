using esxl.ui.Properties;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Docking.Crown;

namespace esxl.Forms.Docking
{
    public partial class DockProject : CrownToolWindow
    {
        #region Constructor Region

        public DockProject()
        {
            InitializeComponent();

            BackColor = System.Drawing.Color.Transparent;

            // Build dummy nodes
            int childCount = 0;
            for (int i = 0; i < 20; i++)
            {
                CrownTreeNode node = new($"Root node #{i}")
                {
                    ExpandedIcon = Resources.folder_16x,
                    Icon =Resources.folder_Closed_16xLG
                };

                for (int x = 0; x < 10; x++)
                {
                    CrownTreeNode childNode = new($"Child node #{childCount}")
                    {
                        Icon = Resources.Files_7954
                    };
                    childCount++;
                    node.Nodes.Add(childNode);
                }

                treeProject.Nodes.Add(node);
            }
        }

        #endregion
    }
}