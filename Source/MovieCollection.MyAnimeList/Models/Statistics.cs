namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Statistics
    {
        [JsonProperty("status")]
        public StatisticsStatus? Status { get; set; }

        [JsonProperty("num_list_users")]
        public int NumListUsers { get; set; }
    }
}
