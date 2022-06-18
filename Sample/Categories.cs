using DevExpress.XtraBars;
using System.Linq;
using TeetSurvey.Repository.Model;

namespace Sample
{
    public partial class Categories : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Categories()
        {
            InitializeComponent();
       var dataSource = new Model().Categories.ToList();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "Categories Count: " + dataSource.Count;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}