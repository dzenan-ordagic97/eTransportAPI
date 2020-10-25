using eTransport.Mobile.Views;
using eTransport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CargoReservationDetailsViewModel : BaseViewModel
    {
        private readonly APIService _cargoReservationService = new APIService("CargoReservation");
        private readonly APIService _freightService = new APIService("Freight");

        public int carrierId;
        public int CargoReservationID;

        public CargoReservationDetailsViewModel()
        {
            InitCommand = new Command(async (param) => await Init((int)param));
            SendMessageCommand = new Command(async () => await SendMessage());
            CancelCommand = new Command(async () => await Cancel());
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
        string _startDateTransport = string.Empty;
        public string StartDateTransport
        {
            get { return _startDateTransport; }
            set { SetProperty(ref _startDateTransport, value); }
        }
        string _endDateTransport = string.Empty;
        public string EndDateTransport
        {
            get { return _endDateTransport; }
            set { SetProperty(ref _endDateTransport, value); }
        }
        string _cargo = string.Empty;
        public string Cargo
        {
            get { return _cargo; }
            set { SetProperty(ref _cargo, value); }
        }
        string _carrier = string.Empty;
        public string Carrier
        {
            get { return _carrier; }
            set { SetProperty(ref _carrier, value); }
        }
        string _extraServices = string.Empty;
        public string ExtraServices
        {
            get { return _extraServices; }
            set { SetProperty(ref _extraServices, value); }
        }

        //Komande
        public ICommand InitCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        private async Task Cancel()
        {
            var cargo = await _cargoReservationService.GetById<CargoReservation>(CargoReservationID);
            await _cargoReservationService.Delete<Model.CargoReservation>(CargoReservationID);
            if (cargo.FreightID != null)
            {
                await _freightService.Delete<Model.Freight>(cargo.FreightID.GetValueOrDefault());
            }
            await Application.Current.MainPage.DisplayAlert("OK", "Succesful cancel!", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async Task SendMessage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ChatPage(carrierId));
        }
        public async Task Init(int cargoReservationID)
        {
            try
            {
                var cargo = await _cargoReservationService.GetById<CargoReservation>(cargoReservationID);
                StartLocation = cargo.StartLocation;
                EndLocation = cargo.EndLocation;
                StartDateTransport = cargo.StartDateTransport.ToString("dd.MM.yyyy");
                EndDateTransport = cargo.EndDateTransport.ToString("dd.MM.yyyy");
                Cargo = cargo.Cargo.Name;
                cargoReservationID = cargo.CargoReservationID;
                if (cargo.ExtraServices == null)
                {
                    ExtraServices = "No extra service";
                }
                else
                {
                    ExtraServices = cargo.ExtraServices.Name;
                }
                if (cargo.Freight == null)
                {
                    Carrier = "No carrier";
                }
                else
                {
                    Carrier = cargo.Freight.Carrier.CarrierName;
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
