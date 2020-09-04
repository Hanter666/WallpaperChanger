using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Net.Http;
using System.Threading.Tasks;
using WallpaperChanger.Json;

namespace WallpaperChanger.Api
{
    public class DeviantArtApiOld : IApi
    {
        private const string tokenUrl =
            "https://www.deviantart.com/oauth2/token?grant_type=client_credentials&client_id=&client_secret=";

        private const string _tokenCheckUrl = "https://www.deviantart.com/api/v1/oauth2/placebo?access_token=";
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly IJsonReader _reader;
        private string _token;

        public DeviantArtApiOld(HttpClient client, ILogger<DeviantArtApiOld> logger,IJsonReader reader)
        {
            _client = client;
            _logger = logger;
            _reader = reader;
        }

        public DeviantArtApiOld()
        {
            _client = new HttpClient();
            _logger = new Logger<DeviantArtApiOld>(new NullLoggerFactory());
            _reader = new JsonReader();
            if (!IsTokenValid(_token))
            {
                _token= GetNewToken();
            }
        }

        private bool IsTokenValid(string token)
        {
            using var result = _client.GetAsync(_tokenCheckUrl + token).Result;
            using var responseContent = result.Content;
            var jsonString = responseContent.ReadAsStringAsync().Result;
            var responseJson = _reader.Deserialize(jsonString);
            _logger.LogDebug("Check token experience");
            return responseJson.TryGetValue("status", out var val) && val == "success";
        }

        private string GetNewToken()
        {
            using var result = _client.GetAsync(tokenUrl).Result;
            using var responseContent = result.Content;
            var jsonString = responseContent.ReadAsStringAsync().Result;
            var responseJson = _reader.Deserialize(jsonString);
            _logger.LogDebug("Check token experience");
            if (responseJson.TryGetValue("status", out var val) && val == "success")
            {
                return responseJson["access_token"]??string.Empty;
            }
            return string.Empty;
        }

        public Task<Image[]> FindByTag(string tag)
        {
            _logger.LogDebug("Requesting image with tag {tag}", tag);
            return Task.FromResult(new Image[0]);
        }
    }
}
