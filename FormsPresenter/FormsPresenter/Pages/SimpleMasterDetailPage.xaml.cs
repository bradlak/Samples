using System.Linq;
using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleMasterDetailPage : MasterDetailPage
    {
        public SimpleMasterDetailPage()
        {
            InitializeComponent();
            var masterPage = new SimpleMasterPage();
            masterPage.PagesList.ItemSelected += (sender, e) =>
            {
                var selected = (NamedColor)e.SelectedItem;
                var newDetail = new ColorPage();
                newDetail.SetProperties(selected);

                Detail = new NavigationPage(newDetail);
                IsPresented = false;
            };

            Master = masterPage;

            var firstDetail = new ColorPage();
            firstDetail.SetProperties(App.Colors.FirstOrDefault());
            Detail = new NavigationPage(firstDetail);
        }
    }
}
