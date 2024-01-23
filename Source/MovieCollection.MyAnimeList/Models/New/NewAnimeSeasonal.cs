namespace MovieCollection.MyAnimeList.Models
{
    public class NewAnimeSeasonal : NewSearchBase
    {
        public NewAnimeSeasonal()
        {
            SeasonName = string.Empty;
        }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        /// <remarks>
        /// Valid values are: winter, spring, summer, fall.
        /// </remarks>
        public string SeasonName { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <remarks>
        /// Valid values are: anime_score, anime_num_list_users.
        /// </remarks>
        public string? Sort { get; set; }
    }
}
