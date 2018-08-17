using System;
using System.Net.Http;
using System.Threading.Tasks;
using Experimentation.Domain.ApiDataModel;
using Newtonsoft.Json;

namespace Experimentation.Domain
{
    public class SocialMediaApiClient : ISocialMediaApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string GetTweets()
        {
            //throw new NotImplementedException();
            return string.Empty;
        }

        public async Task<UserApiDataModel> GetUser(string clientName)
        {
            var user = new UserApiDataModel();
            var client = _httpClientFactory.CreateClient(clientName);
            var endPoint = new Uri(string.Concat(client.BaseAddress, GetUserApiUrl(clientName)));
            var response = await client.GetAsync(endPoint);
            if (response != null)
            {
                string result;
                using (var content = response.EnsureSuccessStatusCode().Content)
                {
                    result = await content.ReadAsStringAsync();
                }
                user = JsonConvert.DeserializeObject<UserApiDataModel>(result);
            }
            return user;
        }

        #region Private Methods

        private static string GetUserApiUrl(string clientName)
        {
            var resultUrl = string.Empty;

            switch (clientName)
            {
                case "twitterClient":
                    resultUrl = "/twitter/user";
                    break;
                case "reqres":
                    resultUrl = "api/users/2";
                    break;
            }
            return resultUrl;
        }

        #endregion
    }
}
