using eTransport.Mobile.Views;
using eTransport.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class ProfileVM : BaseViewModel
    {
        private readonly APIService _serviceClient = new APIService("Client");
        Regex regexNumbers = new Regex(@"^[0-9]*$");
        Regex regexLetters = new Regex(@"^[a-zA-Z\s]*$");
        public bool trigger;

        public ProfileVM()
        {
            LogoutCommand = new Command(async () => await Logout());
            ProfileCommand = new Command(async () => await Init());
            UpdateCommand = new Command(async () => await Update());
            BackCommand = new Command(async () => await Back());
        }
        //Text
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
        public ICommand ProfileCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async Task Logout()
        {
           Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
        public async Task Init()
        {
            var request = await _serviceClient.Get<List<Model.Client>>(null);
            FirstName = request[0].FirstName;
            LastName = request[0].LastName;
            DateOfBirth = request[0].DateOfBirth;
            Gender = request[0].Gender;
            JMBG = request[0].JMBG;
        }
        public async Task Update()
        {
            trigger = false;
            if (FirstName == "" ||  !regexLetters.IsMatch(FirstName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid first name (Only letters)!", "OK");
            }
            else if (LastName == "" || !regexLetters.IsMatch(LastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid last name (Only letters)!", "OK");
            }else if (Gender == "" || ((Gender != "Male") && (Gender != "Female")))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Only 'Male' or 'Female' is accepted!", "OK");
            }
            else if (JMBG == "" || !regexNumbers.IsMatch(JMBG) || JMBG.Length != 13)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid JMBG (Only 13 numbers)!", "OK");
            }
            else
            {
                IsBusy = true;
                trigger = true;
                var requestClientID = await _serviceClient.Get<List<Model.Client>>(null);
                var request = new ClientInsertRequest
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    DateOfBirth = DateOfBirth,
                    Gender = Gender,
                    JMBG = JMBG
                };
                try
                {
                    await _serviceClient.Update<Model.Client>(requestClientID[0].ClientID, request);
                    await Application.Current.MainPage.DisplayAlert("OK", "Succesful update", "OK");
                    IsBusy = false;
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
