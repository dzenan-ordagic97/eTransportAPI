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
    public partial class TransactionPage : ContentPage
    {
        private TransactionViewModel model = null;

        public TransactionPage()
        {
            InitializeComponent();
            BindingContext = model = new TransactionViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.TransactionList.Count == 0)
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                errorLabel.IsVisible = false;
            }
        }
        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Info", "Do you want to complete the following transaction?", "Yes", "No");
            if (result == true)
            {
                await Navigation.PushAsync(new PaymentPage(((eTransport.Model.CargoReservation)e.SelectedItem).FreightID.GetValueOrDefault()));
            }
            else
            {
                await model.Init();
            }
        }
    }
}