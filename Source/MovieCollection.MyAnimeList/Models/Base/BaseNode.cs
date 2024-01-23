namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class BaseNode<T>
    {
        [JsonProperty("node")]
        public T? Node { get; set; }
    }
}
