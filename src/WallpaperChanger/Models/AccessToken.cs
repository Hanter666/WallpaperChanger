using System;

namespace WallpaperChanger.Models
{
    public class AccessToken
    {
        public string Token { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Token) && ExpirationDate < DateTimeOffset.Now;
        }
    }
}
