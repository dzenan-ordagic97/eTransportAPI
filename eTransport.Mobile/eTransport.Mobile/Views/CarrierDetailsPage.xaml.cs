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
    public partial class CarrierDetailsPage : ContentPage
    {
        private readonly int _carrierID;
        CarrierDetailsViewModel model = null;

        public CarrierDetailsPage(int CarrierID)
        {
            InitializeComponent();
            BindingContext = model = new CarrierDetailsViewModel();
            _carrierID = CarrierID;
            model.CarrierID = CarrierID;

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_carrierID);
            if (model.ExtraServicesList.Count == 0)
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                errorLabel.IsVisible = false;
            }
        }
    }
}