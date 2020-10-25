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
    public partial class AddCommentRatingPage : ContentPage
    {
        private readonly int _cargoReservationID;
        private AddCommentRatingViewModel model = null;
        public AddCommentRatingPage(int CargoReservationID)
        {
            InitializeComponent();
            BindingContext = model = new AddCommentRatingViewModel();
            _cargoReservationID = CargoReservationID;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadCargoReservations(_cargoReservationID);
        }
    }
}