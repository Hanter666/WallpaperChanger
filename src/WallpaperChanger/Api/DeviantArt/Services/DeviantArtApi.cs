using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WallpaperChanger.Api.DeviantArt.Models;
using WallpaperChanger.Json;
using WallpaperChanger.Models;

namespace WallpaperChanger.Api.DeviantArt.Services
{
    public class DeviantArtApi : IApi
    {
        private const string AUTHORIZATION_URI = "https://www.deviantart.com/oauth2/token?grant_type=client_credentials&client_id={0}&client_secret={1}";

        private readonly HttpClient _client;
        private readonly Credentials _credentials;
        private readonly IJsonDeserializer _deserializer;
        private readonly ILogger _logger;

        private AccessToken _token;
        
        public DeviantArtApi(HttpClient client, Credentials credentials, IJsonDeserializer deserializer, ILogger<DeviantArtApi> logger)
        {
            _client = client;
            _credentials = credentials;
            _deserializer = deserializer;
            _logger = logger;

            _token = new AccessToken();
        }

        private async Task AuthorizeRequest(HttpRequestMessage message)
        {
            if(!_token.IsValid())
            {
                _token = await GetNewAccessToken();
            }

            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token.Token);
        }

        private async Task<AccessToken> GetNewAccessToken()
        {
            _logger.LogDebug("Requesting new access token for Devianart");

            var url = string.Format(AUTHORIZATION_URI, _credentials.Username, _credentials.Password);
            var response = await _client.GetAsync(url);
            var responseStream = await response.Content.ReadAsStreamAsync();
            var tokenReponse = await _deserializer.Deserialize<AccessTokenResponse>(responseStream);
            
            if(tokenReponse.Status != "success")
            {
                _logger.LogError("Failed to get new access token for Devianart");
                throw new InvalidOperationException("DeviantArt authentication failed");
            }

            var token = new AccessToken
            {
                Token = tokenReponse.AccessToken,
                ExpirationDate = DateTimeOffset.Now.AddSeconds(tokenReponse.ExpiresIn).AddSeconds(-5 * 60)
            };

            return token;
        }

        public async Task<Image[]> FindByTag(string tag)
        {
            var url = $"https://www.deviantart.com/api/v1/oauth2/deviation/{tag}";
            _logger.LogDebug("Requesting url {url}", url);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            await AuthorizeRequest(request);

            var response = await _client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStreamAsync();
            var deviation = await _deserializer.Deserialize<DeviationObject>(responseContent);
            return new Image[0];
        }
    }
}
