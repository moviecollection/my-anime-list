using System;
using System.Net.Http;
using System.Threading.Tasks;
using MovieCollection.MyAnimeList;
using MovieCollection.MyAnimeList.Models;

// HttpClient is intended to be instantiated once per application, rather than per-use.
// See https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
var httpClient = new HttpClient();

var options = new MyAnimeListOptions
{
    ApiKey = "your-api-key",
};

var service = new MyAnimeListService(httpClient, options);

await InitializeMenu();

async Task InitializeMenu()
{
Start:
    Console.Clear();
    Console.WriteLine("Welcome to the 'MyAnimeList' demo.\n");

    Console.WriteLine("1. Get Anime List");
    Console.WriteLine("2. Get Anime Details");
    Console.WriteLine("3. Get Anime Ranking");
    Console.WriteLine("4. Get Anime Seasonal");

    Console.Write("\nPlease select an option: ");
    int input = Convert.ToInt32(Console.ReadLine());

    Console.Clear();

    var task = input switch
    {
        1 => GetAnimeListAsync(),
        2 => GetAnimeDetailsAsync(),
        3 => GetAnimeRankingsAsync(),
        4 => GetAnimeSeasonalAsync(),
        _ => null,
    };

    if (task != null)
    {
        await task;
    }

    Console.WriteLine("\nPress any key to go back to the menu...");
    Console.ReadKey();

    goto Start;
}

async Task GetAnimeListAsync()
{
    var search = new NewAnimeSearch
    {
        Query = "jjk",
    };

    var result = await service.GetAnimeListAsync(search);

    foreach (var item in result.Data)
    {
        Console.WriteLine($"Id: {item.Node.Id}");
        Console.WriteLine($"Title: {item.Node.Title}");
        Console.WriteLine($"Main Picture (Medium): {item.Node.MainPicture.Medium}");
        Console.WriteLine($"Main Picture (Large): {item.Node.MainPicture.Medium}");

        Console.WriteLine();
    }
}

async Task GetAnimeDetailsAsync()
{
    var search = new NewAnimeDetails
    {
        AnimeId = 51009,
        Fields = AnimeFields.All,
    };

    var item = await service.GetAnimeDetailsAsync(search);

    Console.WriteLine($"Id: {item.Id}");
    Console.WriteLine($"Title: {item.Title}");

    Console.WriteLine($"StartDate: {item.StartDate}");
    Console.WriteLine($"EndDate: {item.EndDate}");
    Console.WriteLine($"Synopsis: {item.Synopsis}");

    Console.WriteLine($"Mean: {item.Mean}");
    Console.WriteLine($"Rank: {item.Rank}");
    Console.WriteLine($"Popularity: {item.Popularity}");

    Console.WriteLine($"NumListUsers: {item.NumListUsers}");
    Console.WriteLine($"NumScoringUsers: {item.NumScoringUsers}");
    Console.WriteLine($"Nsfw: {item.Nsfw}");

    Console.WriteLine($"CreatedAt: {item.CreatedAt}");
    Console.WriteLine($"UpdatedAt: {item.UpdatedAt}");

    Console.WriteLine($"MediaType: {item.MediaType}");
    Console.WriteLine($"Status: {item.Status}");

    Console.WriteLine($"NumEpisodes: {item.NumEpisodes}");

    Console.WriteLine($"Start Season Year: {item.StartSeason.Year}");
    Console.WriteLine($"Start Season: {item.StartSeason.SeasonName}");

    Console.WriteLine($"Broadcast StartTime: {item.Broadcast.StartTime}");
    Console.WriteLine($"Broadcast DayOfTheWeek: {item.Broadcast.DayOfTheWeek}");

    Console.WriteLine($"Source: {item.Source}");
    Console.WriteLine($"AverageEpisodeDuration: {item.AverageEpisodeDuration}");
    Console.WriteLine($"Rating: {item.Rating}");

    Console.WriteLine($"Background: {item.Background}");
    Console.WriteLine($"Main Picture (Medium): {item.MainPicture.Medium}");
    Console.WriteLine($"Main Picture (Large): {item.MainPicture.Medium}");

    Console.WriteLine();
}

async Task GetAnimeRankingsAsync()
{
    var search = new NewAnimeRanking
    {
        RankingType = "all",
    };

    var result = await service.GetAnimeRankingsAsync(search);

    foreach (var item in result.Data)
    {
        Console.WriteLine($"Id: {item.Node.Id}");
        Console.WriteLine($"Title: {item.Node.Title}");
        Console.WriteLine($"Rank: {item.Ranking.Rank}");

        Console.WriteLine();
    }
}

async Task GetAnimeSeasonalAsync()
{
    var search = new NewAnimeSeasonal
    {
        Year = 2023,
        SeasonName = "summer",
    };

    var result = await service.GetAnimeSeasonalAsync(search);

    Console.WriteLine(result.Season.Year);
    Console.WriteLine(result.Season.SeasonName);
    Console.WriteLine();

    foreach (var item in result.Data)
    {
        Console.WriteLine($"Id: {item.Node.Id}");
        Console.WriteLine($"Title: {item.Node.Title}");
        Console.WriteLine($"Source: {item.Node.Source}");
        Console.WriteLine($"Background: {item.Node.Background}");

        Console.WriteLine();
    }
}
