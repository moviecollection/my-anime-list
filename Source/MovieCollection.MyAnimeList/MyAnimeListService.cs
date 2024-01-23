namespace MovieCollection.MyAnimeList
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using MovieCollection.MyAnimeList.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// The <see cref="MyAnimeListService"/> class.
    /// </summary>
    public class MyAnimeListService
    {
        private readonly HttpClient _httpClient;
        private readonly MyAnimeListOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyAnimeListService"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
        /// <param name="options">An instance of <see cref="MyAnimeListOptions"/>.</param>
        public MyAnimeListService(HttpClient httpClient, MyAnimeListOptions options)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(_options.ApiAddress))
            {
                throw new ArgumentException($"'{nameof(_options.ApiAddress)}' cannot be null or whitespace.", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(_options.ApiKey))
            {
                throw new ArgumentException($"'{nameof(_options.ApiKey)}' cannot be null or whitespace.", nameof(options));
            }
        }

        /// <summary>
        /// Search for anime.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewAnimeSearch"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<BaseNode<Anime>>?> GetAnimeListAsync(NewAnimeSearch search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(search.Query))
            {
                parameters.Add("q", search.Query);
            }

            if (search.Limit.HasValue)
            {
                parameters.Add("limit", search.Limit);
            }

            if (search.Offset.HasValue)
            {
                parameters.Add("offset", search.Offset);
            }

            if (search.Fields.Count != 0)
            {
                parameters.Add("fields", string.Join(",", search.Fields));
            }

            return GetJsonAsync<PagedResult<BaseNode<Anime>>>("/v2/anime", parameters);
        }

        /// <summary>
        /// Get the details about an anime.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewAnimeSearch"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Anime?> GetAnimeDetailsAsync(NewAnimeDetails search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (search.AnimeId is null)
            {
                throw new ArgumentException($"'{nameof(search.AnimeId)}' cannot be null.", nameof(search));
            }

            var parameters = new Dictionary<string, object>();

            if (search.Fields.Count != 0)
            {
                parameters.Add("fields", string.Join(",", search.Fields));
            }

            // TODO: Add the token.
            return GetJsonAsync<Anime>($"/v2/anime/{search.AnimeId}", parameters);
        }

        /// <summary>
        /// Get the anime rankings.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewAnimeSearch"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<RankingNode<Anime>>?> GetAnimeRankingsAsync(NewAnimeRanking search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(search.RankingType))
            {
                parameters.Add("ranking_type", search.RankingType);
            }

            if (search.Limit.HasValue)
            {
                parameters.Add("limit", search.Limit);
            }

            if (search.Offset.HasValue)
            {
                parameters.Add("offset", search.Offset);
            }

            if (search.Fields.Count != 0)
            {
                parameters.Add("fields", string.Join(",", search.Fields));
            }

            return GetJsonAsync<PagedResult<RankingNode<Anime>>>("/v2/anime/ranking", parameters);
        }

        /// <summary>
        /// Get seasonal anime.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewAnimeSeasonal"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SeasonalResult<BaseNode<Anime>>?> GetAnimeSeasonalAsync(NewAnimeSeasonal search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (string.IsNullOrEmpty(search.SeasonName))
            {
                throw new ArgumentException($"'{nameof(search.SeasonName)}' cannot be null or empty.", nameof(search));
            }

            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(search.Sort))
            {
                parameters.Add("sort", search.Sort);
            }

            if (search.Limit.HasValue)
            {
                parameters.Add("limit", search.Limit);
            }

            if (search.Offset.HasValue)
            {
                parameters.Add("offset", search.Offset);
            }

            if (search.Fields.Count != 0)
            {
                parameters.Add("fields", string.Join(",", search.Fields));
            }

            return GetJsonAsync<SeasonalResult<BaseNode<Anime>>>($"/v2/anime/season/{search.Year}/{search.SeasonName}", parameters);
        }

        // TODO: Add the missing methods.

        private static string GetParametersString(Dictionary<string, object> parameters)
        {
            var builder = new StringBuilder();

            foreach (var item in parameters)
            {
                builder.Append(builder.Length == 0 ? "?" : "&");
                builder.Append($"{item.Key}={item.Value}");
            }

            return builder.ToString();
        }

        private async Task<T?> GetJsonAsync<T>(string requestUrl, Dictionary<string, object>? parameters = null, string? token = null)
        {
            string url = _options.ApiAddress + requestUrl;

            if (parameters is not null && parameters.Count != 0)
            {
                url += GetParametersString(parameters);
            }

            using var request = new HttpRequestMessage(HttpMethod.Get, url);

            return await SendRequestAsync<T>(request, token)
                .ConfigureAwait(false);
        }

        private async Task<T?> SendRequestAsync<T>(HttpRequestMessage request, string? token = null)
        {
            request.Headers.Add("X-MAL-CLIENT-ID", _options.ApiKey);

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Set the user agent if it was explicitly set via the options.
            // This overrides the default request headers.
            if (_options.ProductInformation != null)
            {
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue(_options.ProductInformation));
            }

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var response = await _httpClient.SendAsync(request)
                .ConfigureAwait(false);

            string json = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
