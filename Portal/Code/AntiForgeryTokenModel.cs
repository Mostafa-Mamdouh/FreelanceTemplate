using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Code
{
    public sealed class AntiForgeryTokenModel
    {
        [JsonProperty("antiForgeryToken")]
        public string AntiForgeryToken { get; set; } 
    }
}