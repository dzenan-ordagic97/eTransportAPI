using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eTransport.Mobile.Services;
using eTransport.Mobile.Views;
using System.Diagnostics;

namespace eTransport.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage());

        }
        protected override void OnStart()
        {

        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
