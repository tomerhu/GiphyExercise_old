using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GiphyWebApi.Interfaces;
using GiphyWebApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GiphyWebApi.Tools
{
    public class GiphyTools :IGiphyTools
    {
        private readonly IWebTools _webTools = new WebTools();
        private readonly string _giphyUrl;
        private readonly string _apiKey;

        public GiphyTools(GiphyConfig giphyConfig)
        {
            _apiKey = giphyConfig.ApiKey;
            _giphyUrl = giphyConfig.GiphyUrl;
        }

        public async Task<GifResult> GifFetch(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                throw new FormatException("query term is required");
            }
            SearchParameters searchParameters = new SearchParameters();
            searchParameters.ApiKey = _apiKey;
            searchParameters.Query = searchTerm;

            var searchString = WebTools.ToKeyValueURL(searchParameters);

            var result = await _webTools.GetData(new Uri($"{_giphyUrl}{searchString}"));

            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get GIFs: {result.Result}");
            }

            GifResult gifResult = JsonConvert.DeserializeObject<GifResult>(result.Result);
            return gifResult;
        }
    }
}
