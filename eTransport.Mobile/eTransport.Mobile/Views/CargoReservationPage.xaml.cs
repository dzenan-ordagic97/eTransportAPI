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
    public partial class CargoReservationPage : ContentPage
    {
        private CargoReservationViewModel model = null;
        public CargoReservationPage()
        {
            InitializeComponent();
            BindingContext = model = new CargoReservationViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.CargoReservationList.Count == 0)
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                errorLabel.IsVisible = false;
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var result = await Application.Current.MainPage.DisplayAlert("Info", "Do you want to see the details?", "Yes", "No");
            if (result == true)
            {
                await Navigation.PushAsync(new CargoReservationDetails(((eTransport.Model.CargoReservation)e.SelectedItem).CargoReservationID,((eTransport.Model.CargoReservation)e.SelectedItem).Freight.CarrierID));
            }
            else
            {
                await model.Init();
            }
        }
    }
}