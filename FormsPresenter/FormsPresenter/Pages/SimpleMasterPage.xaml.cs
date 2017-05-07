using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleMasterPage : ContentPage
    {
        public ListView PagesList { get; set; }

        public SimpleMasterPage()
        {
            InitializeComponent();
            PagesList = pagesList;

            pagesList.ItemsSource = App.Colors;

            backBtn.Clicked += (sender, e) =>
            {
                Application.Current.MainPage = new MainPage();
            };
        }
    }
}
