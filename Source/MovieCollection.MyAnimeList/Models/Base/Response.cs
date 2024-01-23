namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Response
    {
        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}
