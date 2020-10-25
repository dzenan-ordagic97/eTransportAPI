using eTransport.Mobile.Views;
using eTransport.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CarrierDetailsViewModel : BaseViewModel
    {
        private readonly APIService _carrierService = new APIService("Carrier");
        private readonly APIService _extraServicesService = new APIService("ExtraServices");
        public int CarrierID;

        public CarrierDetailsViewModel()
        {
            InitCommand = new Command(async (param) => await Init((int)param));
            CargoReservationCommand= new Command(async () => await CargoReservation());
            SendMessageCommand = new Command(async () => await SendMessage());
        }
        string _name = string.Empty;
        public string CarrierName
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        string _carrierBusinessMail = string.Empty;
        public string CarrierBusinessMail
        {
            get { return _carrierBusinessMail; }
            set { SetProperty(ref _carrierBusinessMail, value); }
        }
        string _carrierNumber = string.Empty;
        public string CarrierBusinessNumber
        {
            get { return _carrierNumber; }
            set { SetProperty(ref _carrierNumber, value); }
        }
        decimal _startupPrice = decimal.Zero;
        public decimal StartupPrice
        {
            get { return _startupPrice; }
            set { SetProperty(ref _startupPrice, value); }
        }
        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public async Task CargoReservation()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddSpecificCargoReservationPage(CarrierID));
        }
        private async Task SendMessage()
        {
            IsBusy = true;
            await Application.Current.MainPage.Navigation.PushAsync(new ChatPage(CarrierID));
            IsBusy = false;
        }

        //Liste
        public ObservableCollection<ExtraServices> ExtraServicesList { get; set; } = new ObservableCollection<ExtraServices>();

        //Komande
        public ICommand InitCommand { get; set; }
        public ICommand CargoReservationCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }


        public async Task Init(int carrierID)
        {
            try
            {
                var carrier = await _carrierService.GetById<Carrier>(carrierID);
                var request = new Model.Requests.ExtraServicesSearchRequest()
                {
                    CarrierID = carrierID
                };
                CarrierName = carrier.CarrierName;
                CarrierBusinessMail = carrier.CarrierBusinessEmail;
                CarrierBusinessNumber = carrier.BusinessNumber;
                StartupPrice = carrier.StartupPrice;
                Image = carrier.Image;
                var extraServicesList = await _extraServicesService.Get<List<ExtraServices>>(request);
                ExtraServicesList.Clear();
                foreach (var extra in extraServicesList)
                {
                    ExtraServicesList.Add(extra);
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
