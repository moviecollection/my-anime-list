namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Recommendation
    {
        [JsonProperty("node")]
        public BaseAnime? Node { get; set; }

        [JsonProperty("num_recommendations")]
        public int NumRecommendations { get; set; }
    }
}
