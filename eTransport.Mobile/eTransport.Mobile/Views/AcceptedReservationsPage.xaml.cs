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
    public partial class AcceptedReservationsPage : ContentPage
    {
        private AcceptedReservationsViewModel model = null;
        private readonly APIService _serviceFreight = new APIService("Freight");
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private Model.Requests.FreightInsertRequest requestFreight;
        private Model.Requests.CargoReservationInsertRequest requestCargo;



        public AcceptedReservationsPage()
        {
            InitializeComponent();
            BindingContext = model = new AcceptedReservationsViewModel();
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
            var result = await Application.Current.MainPage.DisplayAlert("Info", "Do you accept the price of this reservation?", "Yes", "No");
            if (result == true)
            {
                requestFreight = new Model.Requests.FreightInsertRequest()
                {
                    ClientAccepted = true
                };
                await _serviceFreight.Update<Model.Freight>(((eTransport.Model.CargoReservation)e.SelectedItem).FreightID.GetValueOrDefault(), requestFreight);
                await Application.Current.MainPage.DisplayAlert("OK", "Transaction accepted!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                requestFreight = new Model.Requests.FreightInsertRequest()
                {
                    ClientAccepted = false
                };
                requestCargo = new Model.Requests.CargoReservationInsertRequest()
                {
                    Accepted = false,
                    isClient=true
                };
                await _serviceFreight.Update<Model.Freight>(((eTransport.Model.CargoReservation)e.SelectedItem).FreightID.GetValueOrDefault(), requestFreight);
                await _serviceCargoReservation.Update<Model.CargoReservation>(((eTransport.Model.CargoReservation)e.SelectedItem).CargoReservationID, requestCargo);
                await Application.Current.MainPage.DisplayAlert("OK", "Transaction declined!", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}