using eTransport.Model;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eTransport.Mobile
{
    public class APIService
    {
        public static string Email;
        public static string Password;
        public static class Session
        {
            public static string ImePrezime { get; set; }
            public static string JWT { get; set; }
            public static List<string> Role { get; set; }
        }
        private string _route;

#if DEBUG
        private string _apiURL = "http://localhost:52391/api";
#endif
#if RELEASE
        private string _apiURL = "https://mywebsite.com/";
#endif
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Auth<T>(string email, string pass)
        {
            var url = $"{_apiURL}/{_route}";
            Email = email;
            Password = pass;
            try
            {
                //"email:pass"
                return await url.WithBasicAuth(email, pass).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You are not authorized!", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Incorrect email or password!", "OK");
                }
                return default(T);
            }
        }
        public async Task<T> Recommend<T>()
        {
            var url = $"{_apiURL}/{_route}/{"recommend"}";

            try
            {
                return await url.WithBasicAuth(Email, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You are not authorized!", "OK");
                }
                throw;
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiURL}/{_route}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            var result = await url.WithOAuthBearerToken(Session.JWT).GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You are not authorized!", "OK");
                }
                return default(T);
            }
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiURL}/{_route}";

            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Update<T>(int id, object request)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();
                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<T> Delete<T>(int id)
        {
            var url = $"{_apiURL}/{_route}/{id}";
            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }
                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
        public async Task<bool> Payment(PaymentModel model)
        {
            HttpClient client = new HttpClient();
            var x = await client.PostAsync(_apiURL + "/Payment",
                                   new StringContent(JsonConvert.SerializeObject(model),
                                                     Encoding.UTF8,
                                                     "application/json"));
            return true;
        }
    }
    public class PaymentModel
    {
        public decimal Amount { get; set; }
        public string Token { get; set; }
    }
}
