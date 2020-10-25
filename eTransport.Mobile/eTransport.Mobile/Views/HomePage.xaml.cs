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
    public partial class HomePage : ContentPage
    {
        private HomeViewModel model = null;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = model = new HomeViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await model.Recommended();
            if(model.CarrierList.Count==0)
            {
                errorLabel.IsVisible = true;
            }
            else
            {
                errorLabel.IsVisible = false;
            }
        }
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new CarrierDetailsPage(((eTransport.Model.Carrier)e.SelectedItem).CarrierID));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            btnBest.IsVisible = false;
            btnAll.IsVisible = true;

            CarriersAllLayout.IsVisible = false;
            BestCarrierLayout.IsVisible = true;
        }

        private void btnAll_Clicked(object sender, EventArgs e)
        {
            btnBest.IsVisible = true;
            btnAll.IsVisible = false;

            CarriersAllLayout.IsVisible = true;
            BestCarrierLayout.IsVisible = false;
        }
        //private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    await Navigation.PushAsync(new AddSpecificCargoReservationPage(((eTransport.Model.Carrier)e.SelectedItem).CarrierID));
        //}
    }
}