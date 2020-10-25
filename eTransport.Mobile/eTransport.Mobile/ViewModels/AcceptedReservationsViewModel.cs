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
    public class AcceptedReservationsViewModel:BaseViewModel
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceClient = new APIService("Client");
        private Model.Requests.CargoReservationSearchRequest requestClient;

        public AcceptedReservationsViewModel()
        {
            CargoReservationCommand = new Command(async () => await Init());
        }

        public ObservableCollection<CargoReservation> CargoReservationList { get; set; } = new ObservableCollection<CargoReservation>();
        public ICommand CargoReservationCommand { get; set; }
        public async Task Init()
        {
            var client = await _serviceClient.Get<List<Model.Client>>(null);
            requestClient = new Model.Requests.CargoReservationSearchRequest()
            {
                ClientID = client[0].ClientID,
                isClient = true,
                isAccepted=true
            };
            var list = await _serviceCargoReservation.Get<List<Model.CargoReservation>>(requestClient);
            CargoReservationList.Clear();
            foreach (var cargo in list)
            {
                CargoReservationList.Add(cargo);
            }
        }

    }
}
