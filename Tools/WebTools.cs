using GiphyWebApi.Interfaces;
using GiphyWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiphyWebApi.Tools
{
    public class WebTools : IWebTools
    {
        public async Task<WebResult> GetData(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    WebResult webResult = new WebResult(false);
                    var response = await httpClient.GetAsync(uri);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    webResult.Result = responseContent;
                    webResult.IsSuccess = response.IsSuccessStatusCode;

                    return webResult;
                }
                catch (Exception ex)
                {
                    //TODO LOG
                    return new WebResult(false, ex.Message);
                }
            }
        }
        public static string ToKeyValueURL(object obj)
        {
            var keys = obj.GetType().GetProperties().
                SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute), true))
                .Cast<JsonPropertyAttribute>().Select(j => j.PropertyName).ToArray();

            var values = obj.GetType().GetProperties().ToList().
                Select(p => p.GetValue(obj)).ToArray();


            //var keyvalues = obj.GetType().GetProperties()
            //    .ToList()
            //    .Select(p => $"{p.Name}={p.GetValue(obj)}")
            //    .ToArray();

            var keyValuePairs = Enumerable.Zip(keys, values,
                (key, value) => new KeyValuePair<string, object>(key, value)).ToList().Select(
                k => $"{k.Key}={k.Value}").ToArray();

            

            return string.Join('&', keyValuePairs);

            
        }
    }
}
