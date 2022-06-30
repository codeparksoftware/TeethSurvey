using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class ExTreeView : TreeView
    {
        public ExTreeView()
        {
            InitializeComponent();
            this.AfterSelect += new TreeViewEventHandler(SelectNodeChangedEvent);
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
        }

        public event TreeViewEventHandler SelectedNodeChanged;

        void SelectNodeChangedEvent(object sender, TreeViewEventArgs e)
        {
            SelectedNodeChangedTrigger(sender, e);
        }
        void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (this.SelectedNode == null)
                SelectedNodeChangedTrigger(sender, new TreeViewEventArgs(null));
        }
        void SelectedNodeChangedTrigger(object sender, TreeViewEventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }
    }

}
