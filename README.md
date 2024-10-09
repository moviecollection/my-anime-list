# MyAnimeList API
Unofficial implementation of the MyAnimeList API for .NET

[![NuGet Version][nuget-shield]][nuget]
[![NuGet Downloads][nuget-shield-dl]][nuget]

## Installation
You can install this package via the `Package Manager Console` in Visual Studio.

```powershell
Install-Package MovieCollection.MyAnimeList -PreRelease
```

## Configuration
Get or create a new static `HttpClient` instance if you don't have one already.

```csharp
// HttpClient lifecycle management best practices:
// https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
private static readonly HttpClient httpClient = new HttpClient();
```

Then, you need to set your api key and pass it to the service's constructor.

```csharp
// using MovieCollection.MyAnimeList;

var options = new MyAnimeListOptions
{
    ApiKey = "your-api-key",
};

var service = new MyAnimeListService(httpClient, options);
```

## Anime List
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

Please see the demo project for more examples.

## Limitations
- Some methods has not been implemented (e.g. Authentication, Forum, Manga, Users).

## Notes
- Please read [MyAnimeList][service]'s [terms of use][service-terms] before using their services.

## License
This project is licensed under the [MIT License](LICENSE).

[nuget]: https://www.nuget.org/packages/MovieCollection.MyAnimeList
[nuget-shield]: https://img.shields.io/nuget/v/MovieCollection.MyAnimeList.svg?label=NuGet
[nuget-shield-dl]: https://img.shields.io/nuget/dt/MovieCollection.MyAnimeList?label=Downloads&color=red

[service]: https://myanimelist.net
[service-terms]: https://myanimelist.net/static/apiagreement.html