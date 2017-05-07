using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleNavigationPage : ContentPage
    {
        public SimpleNavigationPage()
        {
            InitializeComponent();

            foreach (var item in App.Colors)
            {
                var button = new Button()
                {
                    Text = "Go to " + item.Name + " page"
                };

                button.Clicked += async (sender, e) =>
                {
                    var colorPage = new ColorPage();
                    colorPage.SetProperties(item);
                    await Navigation.PushAsync(colorPage);
                };

                stack.Children.Add(button);
            }

            var backBtn = new Button()
            {
                Text = "Back"
            };

            backBtn.Clicked += (sender, args) =>
            {
                Application.Current.MainPage = new MainPage();
            };

            stack.Children.Add(backBtn);
        }
    }
}
