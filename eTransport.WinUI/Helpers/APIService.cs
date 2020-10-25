using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTransport.Model;

namespace eTransport.WinUI.Helpers
{
    public class APIService
    {
        public static class Session
        {
            public static string ImePrezime { get; set; }
            public static string JWT { get; set; }
            public static List<string> Role { get; set; }
        }
        private string _route;
        public APIService(string route)
        {
            _route = route;
        }
        public async Task<T> Auth<T>(string email, string pass)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                //"email:pass"
                return await url.WithBasicAuth(email, pass).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception("You are not authenticated!");
                }
                throw new Exception("Incorrect email or password!");
            }
        }
        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
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
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                }
                return default(T);
            }
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            try
            {
                return await url.WithOAuthBearerToken(Session.JWT).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                //var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                //var stringBuilder = new StringBuilder();
                //foreach (var error in errors)
                //{
                //    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                //}
                //return default(T);
                return default(T);
            }
        }
        public async Task<T> Update<T>(int id, object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
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
                return default(T);
            }
        }
        public async Task<T> Delete<T>(int id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
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
                return default(T);
            }
        }
    }
}
