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
    public partial class AddCargoPage : ContentPage
    {
        private AddCargoViewModel model = null;
        public AddCargoPage()
        {
            InitializeComponent();
            BindingContext = model = new AddCargoViewModel();
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