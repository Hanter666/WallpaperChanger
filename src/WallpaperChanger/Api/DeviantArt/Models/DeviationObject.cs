using System;
using System.Text.Json.Serialization;

namespace WallpaperChanger.Api.DeviantArt.Models
{
    public class DeviationObject
    {
        [JsonPropertyName("deviationid")]
        public Guid DeviationId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
