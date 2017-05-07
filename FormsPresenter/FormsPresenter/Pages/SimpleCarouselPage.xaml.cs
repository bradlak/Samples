using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleCarouselPage : CarouselPage
    {
        public SimpleCarouselPage()
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
