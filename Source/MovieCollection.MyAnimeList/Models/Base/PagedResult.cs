namespace MovieCollection.MyAnimeList.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PagedResult<T> : Response
    {
        [JsonProperty("data")]
        public List<T>? Data { get; set; }

        [JsonProperty("paging")]
        public Paging? Paging { get; set; }
    }
}
