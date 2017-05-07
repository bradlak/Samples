using System.Collections.Generic;
using FormsPresenter.Pages;
using Xamarin.Forms;

namespace FormsPresenter
{
    public partial class App : Application
    {
        public static List<NamedColor> Colors { get; set; } = new List<NamedColor>();

        public App()
        {
            InitializeComponent();

            Colors.Add(new NamedColor() {Name = "Red", Color = Color.Red });
            Colors.Add(new NamedColor() { Name = "Green", Color = Color.Green });
            Colors.Add(new NamedColor() { Name = "Yellow", Color = Color.Yellow });
            Colors.Add(new NamedColor() { Name = "Blue", Color = Color.Blue });
            Colors.Add(new NamedColor() { Name = "Pink", Color = Color.Pink });

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
