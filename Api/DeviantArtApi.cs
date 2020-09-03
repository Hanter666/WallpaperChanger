using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WallpaperChanger.Json;

namespace WallpaperChanger.Api
{
    public class DeviantArtApi : IApi
    {
        private const string tokenUrl =
            "https://www.deviantart.com/oauth2/token?grant_type=client_credentials&client_id=&client_secret=";

        private const string _tokenCheckUrl = "https://www.deviantart.com/api/v1/oauth2/placebo?access_token=";
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly IJsonReader _reader;
        private string _token;

        public DeviantArtApi(HttpClient client, ILogger<DeviantArtApi> logger,IJsonReader reader)
        {
            _client = client;
            _logger = logger;
            _reader = reader;
        }

        public DeviantArtApi()
        {
            _client = new HttpClient();
            _logger = new Logger<DeviantArtApi>(new NullLoggerFactory());
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
            return responseJson.TryGetValue("status", out var val) && val.Item1 == "success";
        }

        private string GetNewToken()
        {
            using var result = _client.GetAsync(tokenUrl).Result;
            using var responseContent = result.Content;
            var jsonString = responseContent.ReadAsStringAsync().Result;
            var responseJson = _reader.Deserialize(jsonString);
            _logger.LogDebug("Check token experience");
            if (responseJson.TryGetValue("status", out var val) && val.Item1 == "success")
            {
                return responseJson["access_token"].Item1??string.Empty;
            }
            return string.Empty;
        }
        public Image[] FindByTag(string tag)
        {
            _logger.LogDebug("Requesting image with tag {tag}", tag);
            return  new Image[0];
        }
    }
}
