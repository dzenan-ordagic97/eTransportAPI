using eTransport.Mobile.Services;
using eTransport.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTransport.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CargoDetailsPage : ContentPage
    {
        private readonly int _cargoID;
        CargoDetailsViewModel model = null;
        public CargoDetailsPage(int CargoID)
        {
            InitializeComponent();
            _cargoID = CargoID;
            BindingContext = model = new CargoDetailsViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init(_cargoID);
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            btnUpdate.IsVisible = false;
            btnSave.IsVisible = true;
            btnPicture.IsVisible = true;
            btnDelete.IsEnabled = false;

            lblDescription.IsReadOnly = false;
            lblHeight.IsReadOnly = false;
            lblName.IsReadOnly = false;
            lblWeight.IsReadOnly = false;
            lblWidth.IsReadOnly = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                byte[] image = null;
                // image.Source = ImageSource.FromStream(() => stream);
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    image = ms.ToArray();
                    model.Image = image;
                }
            }
           (sender as Button).IsEnabled = true;
        }
    }
}