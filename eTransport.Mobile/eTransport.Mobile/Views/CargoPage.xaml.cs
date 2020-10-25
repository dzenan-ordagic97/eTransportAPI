using eTransport.Mobile.ViewModels;
using eTransport.Model;
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
    public partial class CargoPage : ContentPage
    {
        private CargoViewModel model = null;
        private readonly APIService _serviceCargo = new APIService("Cargo");
        public CargoPage()
        {
            InitializeComponent();
            BindingContext = model = new CargoViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if(model.CargoList.Count==0)
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
            var result = await Application.Current.MainPage.DisplayAlert("Info", "Do you want to see the details?", "Yes", "No");
            if(result==true)
            {
                await Navigation.PushAsync(new CargoDetailsPage(((eTransport.Model.Cargo)e.SelectedItem).CargoID));
            }
            else
            {
                await model.Init();
            }
        }
    }
}