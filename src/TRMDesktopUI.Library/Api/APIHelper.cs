using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _client;

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            _client = new HttpClient();
            _client.BaseAddress = new Uri(api);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            using (var response = await _client.PostAsync("/token", content))
            {
                if (response.IsSuccessStatusCode == false)
                    throw new Exception(response.ReasonPhrase);

                var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                return result;
            }
        }

        public async Task<LoggedInUserModel> GetLoggedInUserInfo(string token)
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer { token }");

            using (var response = await _client.GetAsync("/User"))
            {
                if (response.IsSuccessStatusCode == false)
                    throw new Exception(response.ReasonPhrase);

                var result = await response.Content.ReadAsAsync<LoggedInUserModel>();
                return result;
            }
        }
    }
}
