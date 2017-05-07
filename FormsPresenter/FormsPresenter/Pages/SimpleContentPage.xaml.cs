using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class SimpleContentPage : ContentPage
    {
        public SimpleContentPage()
        {
            InitializeComponent();
            backBtn.Clicked += (sender, e) =>
            {
                Application.Current.MainPage = new MainPage();
            };
        }
    }
}
