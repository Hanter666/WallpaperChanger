using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperChanger.Json
{
    public interface IJsonReader
    {
        public Dictionary<string, (string,int)> Deserialize(string jsonString);
    }
}
