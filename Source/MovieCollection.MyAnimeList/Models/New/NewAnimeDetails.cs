namespace MovieCollection.MyAnimeList.Models
{
    using System.Collections.Generic;

    public class NewAnimeDetails
    {
        public NewAnimeDetails()
        {
            Fields = new List<string>();
        }

        /// <summary>
        /// Gets or sets the query to search.
        /// </summary>
        public int? AnimeId { get; set; }

        /// <summary>
        /// Gets or sets the additional fields to return.
        /// </summary>
        public IList<string> Fields { get; set; }

        // TODO: Add the token.
    }
}
