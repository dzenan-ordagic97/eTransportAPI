using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class AddCargoViewModel:BaseViewModel
    {
        private readonly APIService _serviceCargo = new APIService("Cargo");
        private readonly APIService _serviceClient = new APIService("Client");
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        public bool trigger = false;
        public AddCargoViewModel()
        {
            SaveCommand = new Command(async () => await Save());
        }
        string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        string _weight = string.Empty;
        public string Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }
        string _height = string.Empty;
        public string Height
        {
            get { return _height; }
            set { SetProperty(ref _height, value); }
        }
        string _width = string.Empty;
        public string Width
        {
            get { return _width; }
            set { SetProperty(ref _width, value); }
        }
        public byte[] _image = null;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        public ICommand SaveCommand { get; set; }
        public async Task Save()
        {
            if (Name == "" || !regexLetters.IsMatch(Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid cargo name (Only letters)!", "OK");
            }
            else if (Description == "" || !regexLetters.IsMatch(Description))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid description (Only letters)!", "OK");
            }
            else if (Weight == "" || !regexNumbers.IsMatch(Weight))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid weight (Only numbers)!", "OK");
            }
            else if (Height == "" || !regexNumbers.IsMatch(Height))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid height (Only numbers)!", "OK");
            }
            else if (Width == "" || !regexNumbers.IsMatch(Width))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid width (Only numbers)!", "OK");
            }
            else if (Image == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload a picture for your cargo!", "OK");
            }
            else if (Image.Length >= 1100000)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please upload a smaller picture size (Max size 1MB)!", "OK");
            }
            else
            {
                IsBusy = true;
                trigger = false;
                var client = await _serviceClient.Get<List<Model.Client>>(null);
                var request = new CargoInsertRequest
                {
                    Name = Name,
                    Description = Description,
                    Image = Image,
                    MaxHeight = float.Parse(Height),
                    MaxWidth = float.Parse(Width),
                    Weight = float.Parse(Weight),
                    ClientID = client[0].ClientID,
                    IsUsed=false
                };
                var list = await _serviceCargo.Get<List<Model.Cargo>>(null);
                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        if (item.Name == Name)
                        {
                            await Application.Current.MainPage.DisplayAlert("OK", "You already added the cargo with that name!", "OK");
                            IsBusy = false;
                            trigger = true;
                        }
                    }
                }
                if (!trigger)
                {
                    try
                    {
                        await _serviceCargo.Insert<Model.Cargo>(request);
                        await Application.Current.MainPage.DisplayAlert("OK", "Succesfully saved", "OK");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

    }
}
