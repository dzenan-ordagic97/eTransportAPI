using eTransport.Mobile.Views;
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
    public class CommentRatingsViewModel : BaseViewModel
    {
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceClient = new APIService("Client");

        public CommentRatingsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            AddCommand = new Command(async () => await Add());
        }
        public ObservableCollection<CargoReservation> CommentRatingList { get; set; } = new ObservableCollection<CargoReservation>();
        public ICommand InitCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public async Task Add()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CommentRatingDetailsPage());
        }
        public async Task Init()
        {
            var resultClient = await _serviceClient.Get<List<Model.Client>>(null);
            var request = new CargoReservationSearchRequest()
            {
                ClientID = resultClient[0].ClientID,
                isFinished = true
            };
            var result = await _serviceCargoReservation.Get<List<CargoReservation>>(request);
            CommentRatingList.Clear();
            foreach (var reservation in result)
            {
                CommentRatingList.Add(reservation);
            }
        }
    }

}
