namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class Broadcast
    {
        /// <summary>
        /// Gets or sets the day of the week broadcast in Japan time (or 'other').
        /// </summary>
        [JsonProperty("day_of_the_week")]
        public string? DayOfTheWeek { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        [JsonProperty("start_time")]
        public string? StartTime { get; set; }
    }
}
