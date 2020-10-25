using eTransport.Mobile.Views;
using eTransport.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CargoReservationViewModel:BaseViewModel
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceClient = new APIService("Client");
        private Model.Requests.CargoReservationSearchRequest requestClient;

        public CargoReservationViewModel()
        {
            CargoReservationCommand = new Command(async () => await Init());
            AddCommand = new Command(async () => await Add());
            AddSpecificCommand = new Command(async () => await AddSpecific());
            ShowAcceptedCommand = new Command(async () => await ShowAccepted());
        }
        public ObservableCollection<CargoReservation> CargoReservationList { get; set; } = new ObservableCollection<CargoReservation>();

        //Komande
        public ICommand CargoReservationCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddSpecificCommand { get; set; }
        public ICommand ShowAcceptedCommand { get; set; }

        string _type = string.Empty;
        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public async Task Add()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddCargoReservationPage());
        }
        public async Task AddSpecific()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSpecificCargoReservationPage(null));
        }
        public async Task ShowAccepted()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AcceptedReservationsPage());
        }

        public async Task Init()
        {
            var client = await _serviceClient.Get<List<Model.Client>>(null);
            requestClient = new Model.Requests.CargoReservationSearchRequest()
            {
                ClientID = client[0].ClientID,
                isClient = true
            };
            var list = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(requestClient);
            
            CargoReservationList.Clear();
            foreach (var cargo in list)
            {
                CargoReservationList.Add(cargo);
                if (cargo.FreightID!=null)
                {
                    cargo.Freight.Carrier.CarrierName = "Specific";
                    if(cargo.Freight.ClientAccepted.GetValueOrDefault())
                    {
                        cargo.Freight.ClientAcceptedString = "Accepted";
                    }
                    else
                    {
                        cargo.Freight.ClientAcceptedString = "Not accepted";
                    }
                }
                else
                {
                    cargo.Freight.Carrier.CarrierName = "Global";
                    cargo.Freight.ClientAcceptedString = "Not accepted";
                }
            }
        }
    }
}
