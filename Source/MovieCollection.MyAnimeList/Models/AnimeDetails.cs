namespace MovieCollection.MyAnimeList.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class AnimeDetails : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("main_picture")]
        public Picture? MainPicture { get; set; }

        [JsonProperty("alternative_titles")]
        public AlternativeTitles? AlternativeTitles { get; set; }

        [JsonProperty("start_date")]
        public string? StartDate { get; set; }

        [JsonProperty("end_date")]
        public string? EndDate { get; set; }

        [JsonProperty("synopsis")]
        public string? Synopsis { get; set; }

        /// <summary>
        /// Gets or sets the mean.
        /// </summary>
        /// <remarks>
        /// When the mean can not be calculated, such as when the number of user scores is small,
        /// the result does not include this field.
        /// </remarks>
        [JsonProperty("mean")]
        public double? Mean { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <remarks>
        /// When the rank can not be calculated, such as when the number of user scores is small,
        /// the result does not include this field.
        /// </remarks>
        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("popularity")]
        public int? Popularity { get; set; }

        /// <summary>
        /// Gets or sets the number of users who have this work in their list.
        /// </summary>
        [JsonProperty("num_list_users")]
        public int NumListUsers { get; set; }

        [JsonProperty("num_scoring_users")]
        public int NumScoringUsers { get; set; }

        [JsonProperty("nsfw")]
        public string? Nsfw { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("media_type")]
        public string? MediaType { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("genres")]
        public List<Genre>? Genres { get; set; }

        // TODO: MyListStatus.

        [JsonProperty("num_episodes")]
        public int NumEpisodes { get; set; }

        [JsonProperty("start_season")]
        public Season? StartSeason { get; set; }

        [JsonProperty("broadcast")]
        public Broadcast? Broadcast { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        /// <summary>
        /// Gets or sets the average length of episode in seconds.
        /// </summary>
        [JsonProperty("average_episode_duration")]
        public int? AverageEpisodeDuration { get; set; }

        [JsonProperty("rating")]
        public string? Rating { get; set; }

        [JsonProperty("pictures")]
        public List<Picture>? Pictures { get; set; }

        [JsonProperty("background")]
        public string? Background { get; set; }

        [JsonProperty("related_anime")]
        public List<RelatedAnime>? RelatedAnime { get; set; }

        // TODO: Related Manga.

        [JsonProperty("recommendations")]
        public List<Recommendation>? Recommendations { get; set; }

        [JsonProperty("studios")]
        public List<Studio>? Studios { get; set; }

        [JsonProperty("statistics")]
        public Statistics? Statistics { get; set; }
    }
}
