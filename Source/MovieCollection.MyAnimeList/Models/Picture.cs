namespace MovieCollection.MyAnimeList.Models
{
    using System;
    using Newtonsoft.Json;

    public class Picture
    {
        [JsonProperty("medium")]
        public Uri? Medium { get; set; }

        [JsonProperty("large")]
        public Uri? Large { get; set; }
    }
}
