using Newtonsoft.Json;
using System.Collections.Generic;

namespace GiphyWebApi.Models
{
    /// <summary>
    /// Gif results model according to Giphy API  (https://developers.giphy.com/docs/api/schema#gif-object)
    /// </summary>
    public class GifResult
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
}
