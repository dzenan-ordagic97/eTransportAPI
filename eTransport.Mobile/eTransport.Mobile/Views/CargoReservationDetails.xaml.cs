using eTransport.Mobile.ViewModels;
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
    public partial class CargoReservationDetails : ContentPage
    {
        private readonly int _cargoReservationID;
        private readonly int? _carrierID;

        CargoReservationDetailsViewModel model = null;
        public CargoReservationDetails(int CargoReservationID, int? CarrierID)
        {
            InitializeComponent();
            _cargoReservationID = CargoReservationID;
            BindingContext = model = new CargoReservationDetailsViewModel();
            if (CarrierID != null)
            {
                model.carrierId = (int)CarrierID;
                _carrierID = CarrierID.GetValueOrDefault();
            }
            model.CargoReservationID = CargoReservationID;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_cargoReservationID);
            if (_carrierID == null || _carrierID == 0)
            {
                SendButton.IsEnabled = false;
            }
        }
    }
}