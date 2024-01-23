namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class RankingNode<T> : BaseNode<T>
    {
        [JsonProperty("ranking")]
        public Ranking? Ranking { get; set; }
    }
}
