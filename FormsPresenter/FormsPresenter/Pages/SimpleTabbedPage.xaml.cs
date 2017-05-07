using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleTabbedPage : TabbedPage
    {
        public SimpleTabbedPage()
        {
            InitializeComponent();

            foreach (var item in App.Colors)
            {
                var colorPage = new ColorPage();
                colorPage.SetProperties(item);
                Children.Add(colorPage);
            }

            Children.Add(new BackPage());
        }
    }
}
