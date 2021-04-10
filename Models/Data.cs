using Newtonsoft.Json;

namespace GiphyWebApi.Models
{
    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("bitly_url")]
        public string BitlyUrl { get; set; }

        [JsonProperty("embed_url")]
        public string EmbedUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("source_tld")]
        public string SourceTld { get; set; }

        [JsonProperty("source_post_url")]
        public string SourcePostUrl { get; set; }

        [JsonProperty("update_datetime")]
        public string UpdateDatetime { get; set; }

        [JsonProperty("create_datetime")]
        public string CreateDatetime { get; set; }

        [JsonProperty("import_datetime")]
        public string ImportDatetime { get; set; }

        [JsonProperty("trending_datetime")]
        public string TrendingDatetime { get; set; }

        //[JsonProperty("images")]
        //public Images Images { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
