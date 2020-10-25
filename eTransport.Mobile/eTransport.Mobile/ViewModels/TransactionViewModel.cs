using eTransport.Model;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class TransactionViewModel
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceClient = new APIService("Client");

        public TransactionViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ObservableCollection<CargoReservation> TransactionList { get; set; } = new ObservableCollection<CargoReservation>();
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            var resultClient = await _serviceClient.Get<List<eTransport.Model.Client>>(null);
            var request = new CargoReservationSearchRequest()
            {
                ClientID = resultClient[0].ClientID,
                isFinished = true,
                Payed = true
            };
            var result = await _serviceCargoReservation.Get<List<CargoReservation>>(request);
            TransactionList.Clear();
            foreach (var reservation in result)
            {
                TransactionList.Add(reservation);
            }
        }
    }
}
