using eTransport.Mobile.ViewModels;
using eTransport.Model;
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
    public partial class AddSpecificCargoReservationPage : ContentPage
    {
        private AddCargoReservationSpecificViewModel model = null;
        private Model.Requests.CitySearchRequest _citySearch;
        private Model.Requests.ExtraServicesSearchRequest _extraServicesSearch;
        private readonly APIService _serviceCity = new APIService("City");
        private readonly APIService _serviceExtraServices = new APIService("ExtraServices");
        private readonly int? _carrierID;
        public AddSpecificCargoReservationPage(int? CarrierID)
        {
            InitializeComponent();
            _citySearch = new Model.Requests.CitySearchRequest();
            _extraServicesSearch = new Model.Requests.ExtraServicesSearchRequest();
            BindingContext = model = new AddCargoReservationSpecificViewModel();
            if (CarrierID != null && CarrierID!=0)
            {
                model._carrierId = (int)CarrierID;
                _carrierID = CarrierID.GetValueOrDefault();
            }
            else
            {
                SendButton.IsVisible = false;
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadCountries();
            await model.LoadCargos();
            if (_carrierID == null || _carrierID==0)
            {
                await model.LoadCarriersAll();
            }
            else
            {
                await model.LoadCarriers(_carrierID);
            }
        }

        private async void pickerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country selectedCountry = (Country)pickerCountry.SelectedItem;
            _citySearch.CountryID = selectedCountry.CountryID;
            var result = await _serviceCity.Get<List<Model.City>>(_citySearch);
            pickerCityStart.ItemsSource = result;
            pickerCityEnd.ItemsSource = result;
        }

        private async void pickerCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carrier selectedCarrier = (Carrier)pickerCarrier.SelectedItem;
            _extraServicesSearch.CarrierID = selectedCarrier.CarrierID;
            var result = await _serviceExtraServices.Get<List<Model.ExtraServices>>(_extraServicesSearch);
            pickerExtraServices.ItemsSource = result;
        }
    }
}