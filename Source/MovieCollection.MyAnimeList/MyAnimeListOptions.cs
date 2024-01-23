namespace MovieCollection.MyAnimeList
{
    using System.Net.Http.Headers;

    /// <summary>
    /// The <see cref="MyAnimeListOptions"/> class.
    /// </summary>
    public class MyAnimeListOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyAnimeListOptions"/> class.
        /// </summary>
        public MyAnimeListOptions()
        {
            ApiAddress = "https://api.myanimelist.net";
            ApiKey = string.Empty;
        }

        /// <summary>
        /// Gets or sets the api address.
        /// </summary>
        public string ApiAddress { get; set; }

        /// <summary>
        /// Gets or sets the api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the name (and version) of the product using this library.
        /// </summary>
        public ProductHeaderValue? ProductInformation { get; set; }
    }
}
