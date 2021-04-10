using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyWebApi.Models
{
    public class SearchParameters
    {
        /// <summary>
        /// (required) GIPHY API Key
        /// </summary>
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// (required) GIPHY search query term or phrase
        /// </summary>
        [JsonProperty("q")]
        public string Query { get; set; }

        /// <summary>
        /// (optional) Number of results to return
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 1;

        /// <summary>
        /// (optional) Specifies the starting position of the results, defaults to 0
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// (optional) Filters results by specified rating (y,g, pg, pg-13 or r)
        /// </summary>
        [JsonProperty("rating")]
        public string Rating { get; set; }

        /// <summary>
        /// (optional) Specify default language for regional content; use a 2-letter ISO 639-1 language code
        /// </summary>
        [JsonProperty("lang")]
        public string Language { get; set; }
    }
}
