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
    public class AddCommentRatingViewModel : BaseViewModel
    {
        private readonly APIService _serviceCommentRating = new APIService("CommentRating");
        private readonly APIService _serviceCargoReservation = new APIService("CargoReservation");
        private readonly APIService _serviceClient = new APIService("Client");
        private readonly APIService _serviceFreight = new APIService("Freight");
        private readonly APIService _serviceRatingCarrier = new APIService("RatingCarrier");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");


        public AddCommentRatingViewModel()
        {
            LoadCommand = new Command(async (param) => await LoadCargoReservations((int)param));
            CargoReservationCommand = new Command(async () => await Save());
        }
        int _rating = new int();
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        string _comment = string.Empty;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand CargoReservationCommand { get; set; }


        //Liste
        ObservableCollection<CargoReservation> _CargosReservations = new ObservableCollection<CargoReservation>();
        public ObservableCollection<CargoReservation> CargoReservations
        {
            get { return _CargosReservations; }
            set { SetProperty(ref _CargosReservations, value); }
        }
        private CargoReservation _selectedCargo;
        public CargoReservation SelectedCargo
        {
            get { return _selectedCargo; }
            set { SetProperty(ref _selectedCargo, value); }
        }
        public async Task LoadCargoReservations(int cargoReservationID)
        {
            var result = await _serviceCargoReservation.GetById<Model.CargoReservation>(cargoReservationID);
            _CargosReservations.Clear();
            _CargosReservations.Add(result);
        }
        public async Task Save()
        {
            if (Comment == "" || !regexLetters.IsMatch(Comment))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a valid comment (Only letters)!", "OK");
            }
            else if (Rating < 1 || Rating > 5 )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please input valid rating (min 1-max 5)!", "OK");
            }else if(SelectedCargo==null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please choose a person you want to review!", "OK");
            }
            else
            {
                IsBusy = true;
                var client = await _serviceClient.Get<List<Model.Client>>(null);
                var requestComment = new CommentRatingInsertRequest
                {
                    ClientID = client[0].ClientID,
                    FreightID = SelectedCargo.FreightID.GetValueOrDefault(),
                    Comment = Comment,
                    Rating = Rating
                };
                var requestFreight = new FreightInsertRequest()
                {
                    isRated = true
                };
                var requestCarrier = new RatingCarrierInsertRequest()
                {
                    CarrierID = SelectedCargo.Freight.CarrierID
                };
                try
                {
                    await _serviceCommentRating.Insert<Model.CommentRating>(requestComment);
                    await _serviceFreight.Update<Model.Freight>(SelectedCargo.FreightID.GetValueOrDefault(), requestFreight);
                    await _serviceRatingCarrier.Insert<Model.RatingCarrier>(requestCarrier);
                    await Application.Current.MainPage.DisplayAlert("Info", "Succesfully saved", "OK");
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
