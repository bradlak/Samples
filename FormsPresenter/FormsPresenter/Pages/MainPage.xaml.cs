using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            contentPageBtn.Clicked += ContentPageBtn_Clicked;
            mdPageBtn.Clicked += MdPageBtn_Clicked;
            navigationPageBtn.Clicked += NavigationPageBtn_Clicked;
            tabbedPageBtn.Clicked += TabbedPageBtn_Clicked;
            carouselPageBtn.Clicked += CarouselPageBtn_Clicked;
        }

        void ContentPageBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SimpleContentPage();
        }

        void MdPageBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SimpleMasterDetailPage();
        }

        void NavigationPageBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SimpleNavigationPage());
        }

        void TabbedPageBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SimpleTabbedPage();
        }

        void CarouselPageBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SimpleCarouselPage();
        }
    }
}
