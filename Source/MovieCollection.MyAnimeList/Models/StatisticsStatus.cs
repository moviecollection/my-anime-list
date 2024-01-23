namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class StatisticsStatus
    {
        [JsonProperty("watching")]
        public string? Watching { get; set; }

        [JsonProperty("completed")]
        public string? Completed { get; set; }

        [JsonProperty("on_hold")]
        public string? OnHold { get; set; }

        [JsonProperty("dropped")]
        public string? Dropped { get; set; }

        [JsonProperty("plan_to_watch")]
        public string? PlanToWatch { get; set; }
    }
}
