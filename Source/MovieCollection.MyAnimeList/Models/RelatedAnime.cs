namespace MovieCollection.MyAnimeList.Models
{
    using Newtonsoft.Json;

    public class RelatedAnime
    {
        [JsonProperty("node")]
        public BaseAnime? Node { get; set; }

        [JsonProperty("relation_type")]
        public string? RelationType { get; set; }

        [JsonProperty("relation_type_formatted")]
        public string? RelationTypeFormatted { get; set; }
    }
}
