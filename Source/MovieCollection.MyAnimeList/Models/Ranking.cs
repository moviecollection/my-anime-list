namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Ranking
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }
    }
}
