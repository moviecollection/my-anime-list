namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class BaseAnime
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("main_picture")]
        public Picture? MainPicture { get; set; }
    }
}
