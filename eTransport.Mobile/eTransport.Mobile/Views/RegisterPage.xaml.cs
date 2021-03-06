﻿using eTransport.Mobile.ViewModels;
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
    public partial class RegisterPage : ContentPage
    {
        private readonly APIService _serviceCity = new APIService("City");
        private Model.Requests.CitySearchRequest _citySearch;

        private RegisterViewModel model = null;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = model = new RegisterViewModel();
            _citySearch = new Model.Requests.CitySearchRequest();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadCountries();
        }

        private async void pickerCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country selectedCountry = (Country)pickerCountry.SelectedItem;
            _citySearch.CountryID = selectedCountry.CountryID;
            var result = await _serviceCity.Get<List<Model.City>>(_citySearch);
            pickerCity.ItemsSource = result;
        }
    }
}