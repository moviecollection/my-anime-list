namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class SeasonalResult<T> : PagedResult<T>
    {
        [JsonProperty("season")]
        public Season? Season { get; set; }
    }
}
