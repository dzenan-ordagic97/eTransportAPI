using eTransport.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTransport.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadersPage : ContentPage
    {
        private HeadersViewModel model = null;

        public HeadersPage()
        {
            InitializeComponent();
            BindingContext = model = new HeadersViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ChatPage(((eTransport.Model.MessageHeader)e.SelectedItem)));
        }
    }
}