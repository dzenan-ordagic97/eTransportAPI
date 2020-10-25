﻿using eTransport.Mobile.Views;
using eTransport.Model;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class AddCargoReservationSpecificViewModel : BaseViewModel
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceCargo = new APIService("Cargo");
        private readonly APIService _serviceClient = new APIService("Client");
        private readonly APIService _serviceCarrier = new APIService("Carrier");
        private readonly APIService _serviceCountries = new APIService("Country");
        private Model.Requests.CarrierSearchRequest request;
        private Model.Requests.CargoReservationInsertRequest requestCargoReservation;

        public int _carrierId;

        public AddCargoReservationSpecificViewModel()
        {
            LoadCommand = new Command(async () => await LoadCargos());
            SendMessageCommand = new Command(async () => await SendMessage());
            LoadCarriersCommand = new Command(async (param) => await LoadCarriers((int?)param));
            LoadCarriersAllCommand = new Command(async () => await LoadCarriersAll());
            CargoReservationCommand = new Command(async () => await Save());
            LoadCountriesCommand = new Command(async () => await LoadCountries());
            requestCargoReservation = new CargoReservationInsertRequest();
        }

        private async Task SendMessage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ChatPage(_carrierId));
        }

        string _startLocation = string.Empty;
        public string StartLocation
        {
            get { return _startLocation; }
            set { SetProperty(ref _startLocation, value); }
        }
        string _endLocation = string.Empty;
        public string EndLocation
        {
            get { return _endLocation; }
            set { SetProperty(ref _endLocation, value); }
        }
        DateTime _startDateTransport = DateTime.Now;
        public DateTime StartDateTransport
        {
            get { return _startDateTransport; }
            set { SetProperty(ref _startDateTransport, value); }
        }
        DateTime _endDateTransport = DateTime.Now;
        public DateTime EndDateTransport
        {
            get { return _endDateTransport; }
            set { SetProperty(ref _endDateTransport, value); }
        }

        //Liste
        ObservableCollection<Cargo> _Cargos = new ObservableCollection<Cargo>();
        public ObservableCollection<Cargo> Cargos
        {
            get { return _Cargos; }
            set { SetProperty(ref _Cargos, value); }
        }
        private Cargo _selectedCargo;
        public Cargo SelectedCargo
        {
            get { return _selectedCargo; }
            set { SetProperty(ref _selectedCargo, value); }
        }

        ObservableCollection<Carrier> _Carriers = new ObservableCollection<Carrier>();
        public ObservableCollection<Carrier> Carriers
        {
            get { return _Carriers; }
            set { SetProperty(ref _Carriers, value); }
        }
        private Carrier _selectedCarrier;
        public Carrier SelectedCarrier
        {
            get { return _selectedCarrier; }
            set { SetProperty(ref _selectedCarrier, value); }
        }

        ObservableCollection<Country> _Countries = new ObservableCollection<Country>();
        public ObservableCollection<Country> Countries
        {
            get { return _Countries; }
            set { SetProperty(ref _Countries, value); }
        }
        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { SetProperty(ref _selectedCountry, value); }
        }

        ObservableCollection<City> _CitiesStart = new ObservableCollection<City>();
        public ObservableCollection<City> CitiesStart
        {
            get { return _CitiesStart; }
            set { SetProperty(ref _CitiesStart, value); }
        }
        private City _selectedCityStart;
        public City SelectedCityStart
        {
            get { return _selectedCityStart; }
            set { SetProperty(ref _selectedCityStart, value); }
        }

        ObservableCollection<City> _CitiesEnd = new ObservableCollection<City>();
        public ObservableCollection<City> CitiesEnd
        {
            get { return _CitiesEnd; }
            set { SetProperty(ref _CitiesEnd, value); }
        }
        private City _selectedCityEnd;
        public City SelectedCityEnd
        {
            get { return _selectedCityEnd; }
            set { SetProperty(ref _selectedCityEnd, value); }
        }

        ObservableCollection<ExtraServices> _ExtraServices = new ObservableCollection<ExtraServices>();
        public ObservableCollection<ExtraServices> ExtraServices
        {
            get { return _ExtraServices; }
            set { SetProperty(ref _ExtraServices, value); }
        }
        private ExtraServices _selectedExtraServices;
        public ExtraServices SelectedExtraServices
        {
            get { return _selectedExtraServices; }
            set { SetProperty(ref _selectedExtraServices, value); }
        }

        //Komande
        public ICommand LoadCommand { get; set; }
        public ICommand LoadCarriersCommand { get; set; }
        public ICommand LoadCarriersAllCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand CargoReservationCommand { get; set; }
        public ICommand LoadCountriesCommand { get; set; }

        public async Task LoadCountries()
        {
            var result = await _serviceCountries.Get<List<Country>>(null);
            _Countries.Clear();
            foreach (var country in result)
            {
                _Countries.Add(country);
            }
        }
        public async Task LoadCargos()
        {
            var result = await _serviceCargo.Get<List<Cargo>>(null);
            _Cargos.Clear();
            foreach (var cargo in result)
            {
                _Cargos.Add(cargo);
            }
        }
        public async Task LoadCarriers(int? CarrierID)
        {
            request = new CarrierSearchRequest()
            {
                IsSingleCarrier = false,
                CarrierID = CarrierID
            };
            var result = await _serviceCarrier.Get<List<Carrier>>(request);
            _Carriers.Clear();
            foreach (var item in result)
            {
                _Carriers.Add(item);
            }
        }
        public async Task LoadCarriersAll()
        {
            request = new CarrierSearchRequest()
            {
                IsSingleCarrier = false,
            };
            var result = await _serviceCarrier.Get<List<Carrier>>(request);
            _Carriers.Clear();
            foreach (var item in result)
            {
                _Carriers.Add(item);
            }
        }
        public async Task Save()
        {
            var client = await _serviceClient.Get<List<Model.Client>>(null);
            if (SelectedCountry == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please choose a valid country!", "OK");
            }
            else if (SelectedCityStart == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please choose a valid start location city!", "OK");
            }
            else if (SelectedCityEnd == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please choose a valid end location city!", "OK");
            }
            else if (StartDateTransport.Date < DateTime.Now.Date)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid dates (Start date can't be lower than todays date)", "OK");
            }
            else if (StartDateTransport.Date > EndDateTransport.Date)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid dates (Start date can't be higher than end date)", "OK");
            }
            else if (SelectedCargo == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select a valid cargo!", "OK");
            }
            else if (SelectedCarrier == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select a valid carrier!", "OK");
            }
          

            else
            {
                IsBusy = true;
                var requestCargo = new CargoInsertRequest()
                {
                    IsUsed = true
                };
                requestCargoReservation.StartDateTransport = StartDateTransport;
                requestCargoReservation.EndDateTransport = EndDateTransport;
                requestCargoReservation.EndLocation = SelectedCityEnd.Name;
                requestCargoReservation.StartLocation = SelectedCityStart.Name;
                requestCargoReservation.CargoID = SelectedCargo.CargoID;
                requestCargoReservation.ClientID = client[0].ClientID;
                if (SelectedExtraServices != null)
                {
                    requestCargoReservation.ExtraServicesID = SelectedExtraServices.ExtraServicesID;
                }
                requestCargoReservation.Freight = new Freight()
                {
                    CarrierID = SelectedCarrier.CarrierID
                };
                //var request = new CargoReservationInsertRequest
                //{
                //    StartDateTransport = StartDateTransport,
                //    EndLocation = SelectedCityEnd.Name,
                //    EndDateTransport = EndDateTransport,
                //    StartLocation = SelectedCityStart.Name,
                //    CargoID = SelectedCargo.CargoID,
                //    ClientID = client[0].ClientID,

                //    ExtraServicesID = SelectedExtraServices.ExtraServicesID,
                //    Freight = new Freight()
                //    {
                //        CarrierID = SelectedCarrier.CarrierID
                //    }
                //};
                try
                {
                    await _serviceCargo.Update<Model.Cargo>(SelectedCargo.CargoID, requestCargo);
                    await _serviceCargoReservation.Insert<Model.CargoReservation>(requestCargoReservation);
                    await Application.Current.MainPage.DisplayAlert("OK", "Succesfully saved", "OK");
                    IsBusy = false;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
