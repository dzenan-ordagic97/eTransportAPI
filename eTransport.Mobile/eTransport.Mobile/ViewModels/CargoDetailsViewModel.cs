using eTransport.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class CargoDetailsViewModel : BaseViewModel
    {
        private readonly APIService _cargoService = new APIService("Cargo");
        private Model.Requests.CargoInsertRequest requestCargo;
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        public CargoDetailsViewModel()
        {
            InitCommand = new Command(async (param) => await Init((int)param));
            DeleteCommand = new Command(async () => await Delete());
            UpdateCommand = new Command(async () => await Update());

        }
        int CargoID;

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
        public ICommand InitCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public async Task Delete()
        {
            IsBusy = true;
            try
            {
                await _cargoService.Delete<Cargo>(CargoID);
                await Application.Current.MainPage.DisplayAlert("Info", "Succesful deletion!", "OK");
                IsBusy = false;
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception)
            {

            }
        }
        public async Task Update()
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
                try
                {
                    requestCargo = new Model.Requests.CargoInsertRequest()
                    {
                        Name = Name,
                        Description = Description,
                        Weight = double.Parse(Weight),
                        MaxHeight = double.Parse(Height),
                        MaxWidth = double.Parse(Width),
                        Image = Image,
                        isUpdate = true
                    };
                    await _cargoService.Update<Cargo>(CargoID, requestCargo);
                    await Application.Current.MainPage.DisplayAlert("Info", "Succesful update!", "OK");
                    IsBusy = false;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception)
                {

                }
            }
        }
        public async Task Init(int cargoID)
        {
            try
            {
                var cargo = await _cargoService.GetById<Cargo>(cargoID);
                Name = cargo.Name;
                Description = cargo.Description;
                Weight = cargo.Weight.ToString();
                Height = cargo.MaxHeight.ToString();
                Width = cargo.MaxWidth.ToString();
                Image = cargo.Image;
                CargoID = cargoID;
            }
            catch (Exception)
            {

            }

        }
    }
}
