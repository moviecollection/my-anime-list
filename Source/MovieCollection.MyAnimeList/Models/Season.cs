namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Season
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("season")]
        public string? SeasonName { get; set; }
    }
}
