namespace MovieCollection.MyAnimeList.Models
{
    using System.Collections.Generic;

    public class NewSearchBase
    {
        public NewSearchBase()
        {
            Fields = new List<string>();
        }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets the additional fields to return.
        /// </summary>
        public IList<string> Fields { get; set; }
    }
}
