namespace MovieCollection.MyAnimeList.Models
{
    using System;
    using Newtonsoft.Json;

    public class Paging
    {
        [JsonProperty("next")]
        public Uri? Next { get; set; }
    }
}
