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
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Users/Auth/Register");
        private readonly APIService _serviceUser = new APIService("Users");
        private readonly APIService _serviceCountry = new APIService("Country");
        Regex regexPassword = new Regex("^(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-+]).{6,}$");
        Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        Regex regexLettersNumbers = new Regex(@"^[a-zA-Z0-9\s]*$");
        Regex regexNumbers = new Regex(@"^[0-9]*$");

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
            LoadCommand = new Command(async () => await LoadCountries());
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        string _jmbg = string.Empty;
        public string JMBG
        {
            get { return _jmbg; }
            set { SetProperty(ref _jmbg, value); }
        }
        string _gender = string.Empty;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }
        DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }
        string _addressName;
        public string AddressName
        {
            get { return _addressName; }
            set { SetProperty(ref _addressName, value); }
        }

        //Liste
        ObservableCollection<Country> _Countries = new ObservableCollection<Country>();
        public ObservableCollection<Country> Countries
        {
            get { return _Countries; }
            set { SetProperty(ref _Countries, value); }
        }
        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { SetProperty(ref _selectedCountry, value); }
        }
        ObservableCollection<City> _Cities = new ObservableCollection<City>();
        public ObservableCollection<City> Cities
        {
            get { return _Cities; }
            set { SetProperty(ref _Cities, value); }
        }
        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { SetProperty(ref _selectedCity, value); }
        }

        //Komande
        public ICommand LoadCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public async Task LoadCountries()
        {
            var result = await _serviceCountry.Get<List<Country>>(null);
            _Countries.Clear();
            foreach (var country in result)
            {
                _Countries.Add(country);
            }
        }
        public async Task Register()
        {
            if (Email == "" || !regexEmail.IsMatch(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid email! (Example: something@gmail.com)", "OK");
            }
            else if (!regexPassword.IsMatch(Password) || Password == "")
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid password (Minimum 6 chars, one number, one uppercase and one special char)!", "OK");
            }
            else if (FirstName == "" || !regexLetters.IsMatch(FirstName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid first name (Only letters)!", "OK");
            }
            else if (LastName == "" || !regexLetters.IsMatch(LastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid last name (Only letters)!", "OK");
            }
            else if (JMBG == "" || !regexNumbers.IsMatch(JMBG) || JMBG.Length != 13)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid JMBG (Only 13 numbers)!", "OK");
            }
            else if (Gender == "" || ((Gender != "Male") && (Gender != "Female")))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Only 'Male' or 'Female' is accepted!", "OK");
            }
            else if (SelectedCity == null || SelectedCountry == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please choose a country and a city!", "OK");
            }
            else if (AddressName == null || !regexLettersNumbers.IsMatch(AddressName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid address name! (Letters and numbers only)", "OK");
            }
            else
            {
                IsBusy = true;
                var request = new ApplicationUserCreateRequest
                {
                    Email = Email,
                    Password = Password,
                    Client = new ClientInsertRequest()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        DateOfBirth = DateOfBirth,
                        Gender = Gender,
                        JMBG = JMBG
                    },
                    Address = new Address()
                    {
                        CityID = SelectedCity.CityID,
                        Name = AddressName
                    }
                };
                var result = await _serviceUser.Get<List<Model.User>>(null);
                foreach (var item in result)
                {
                    if (item.Email == request.Email)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "You are already registered! Please login!", "OK");
                        IsBusy = false;
                        await Application.Current.MainPage.Navigation.PopAsync();
                        return;
                    }
                }
                await _service.Insert<Model.User>(request);
                await Application.Current.MainPage.DisplayAlert("OK", "Succesful registration! Please login!", "OK");
                IsBusy = false;
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
