# MyAnimeList API
Unofficial implementation of the MyAnimeList API for .NET

[![Nuget Version][nuget-shield]][nuget]
[![Nuget Downloads][nuget-shield-dl]][nuget]

## Installing
You can install this package by entering the following command into your `Package Manager Console`:
```powershell
Install-Package MovieCollection.MyAnimeList -PreRelease
```

## Configuration
First, define an instance of the `HttpClient` class if you haven't already.
```csharp
// HttpClient is intended to be instantiated once per application, rather than per-use.
// See https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
private static readonly HttpClient httpClient = new HttpClient();
```

Then, you need to set your api key.
```csharp
// using MovieCollection.MyAnimeList;

var options = new MyAnimeListOptions
{
    ApiKey = "your-api-key",
};

var service = new MyAnimeListService(httpClient, options);
```

## Searching for an Anime
You can search for an anime via the `GetAnimeListAsync` method.
```csharp
var search = new NewAnimeSearch
{
    Query = "jjk",
};

var result = await service.GetAnimeListAsync(search);
```

## Anime Details
You can get anime details via the `GetAnimeDetailsAsync` method.
```csharp
var search = new NewAnimeDetails
{
    AnimeId = 51009,
    Fields = AnimeFields.All,
};

var item = await service.GetAnimeDetailsAsync(search);
```

Please check out the demo project for more examples.

## Limitations
- Some methods has not been implemented (e.g. Authentication, Forum, Manga, Users).

## Notes
- Thanks to [MyAnimeList][service] for providing free API services. 
- Please read MyAnimeList [terms of use][service-terms] before using their services.

## License
This project is licensed under the [MIT License](LICENSE).

[nuget]: https://www.nuget.org/packages/MovieCollection.MyAnimeList
[nuget-shield]: https://img.shields.io/nuget/v/MovieCollection.MyAnimeList.svg?label=Release
[nuget-shield-dl]: https://img.shields.io/nuget/dt/MovieCollection.MyAnimeList?label=Downloads&color=red

[service]: https://myanimelist.net
[service-terms]: https://myanimelist.net/static/apiagreement.html