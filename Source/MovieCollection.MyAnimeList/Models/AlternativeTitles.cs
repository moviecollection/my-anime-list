namespace MovieCollection.MyAnimeList.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AlternativeTitles
    {
        [JsonProperty("synonyms")]
        public List<string>? Synonyms { get; set; }

        [JsonProperty("en")]
        public string? English { get; set; }

        [JsonProperty("ja")]
        public string? Japanese { get; set; }
    }
}
