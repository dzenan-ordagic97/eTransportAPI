using eTransport.Mobile.Views;
using eTransport.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eTransport.Mobile.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Users/Auth");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            GoRegisterPageCommand = new Command(async () => await GoRegisterPage());

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

        public ICommand LoginCommand { get; set; }
        public ICommand GoRegisterPageCommand { get; set; }
       
        async Task GoRegisterPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        async Task Login()
        {
            IsBusy = true;
            var email = Email;
            var pass = Password;
            var user = await _service.Auth<Model.User>(email, pass);
            if (user != null)
            {
                if (!String.IsNullOrEmpty(user.Token))
                {
                    APIService.Session.ImePrezime = user.FirstName + " " + user.LastName;
                    APIService.Session.JWT = user.Token;
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(user.Token);
                    if (jsonToken.ValidTo.ToLocalTime().CompareTo(DateTime.Now.ToLocalTime()) < 1)
                    {
                        APIService.Session.JWT = "";
                        APIService.Session.Role = null;
                        return;
                    }
                    APIService.Session.ImePrezime = user.FirstName + " " + user.LastName;
                    APIService.Session.Role = new List<string>();
                    foreach (var claim in jsonToken.Claims)
                    {
                        if (claim.Type.Equals("role"))
                        {
                            APIService.Session.Role.Add(claim.Value);
                        }

                    }
                    if (APIService.Session.Role.Contains(Model.Helpers.Role.Client))
                    {
                        var page = new NavigationPage(new WelcomePage());
                        page.BarBackgroundColor = Color.FromHex("#009688");
                        Application.Current.MainPage = page;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "You don't have permission!", "OK");
                        IsBusy = false;
                    }
                }
            }
            else
            {
                IsBusy = false;
            }
        }
    }
}
