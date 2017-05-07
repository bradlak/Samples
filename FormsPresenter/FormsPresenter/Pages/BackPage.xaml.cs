using System;
using System.Collections.Generic;
using FormsPresenter.Pages;
using Xamarin.Forms;

namespace FormsPresenter.Pages
{
    public partial class BackPage : ContentPage
    {
        public BackPage()
        {
            InitializeComponent();

            backBtn.Clicked += (sender, e) =>
            {
                Application.Current.MainPage = new MainPage();
            };
        }
    }
}
