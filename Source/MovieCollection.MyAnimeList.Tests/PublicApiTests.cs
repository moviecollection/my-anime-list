namespace MovieCollection.MyAnimeList.Tests
{
    using System.Threading.Tasks;
    using PublicApiGenerator;
    using VerifyXunit;
    using Xunit;

    public class PublicApiTests
    {
        [Fact]
        public Task PublicApiShouldNotChange()
        {
            var publicApi = typeof(MyAnimeListService).Assembly
                .GeneratePublicApi();

            return Verifier.Verify(publicApi);
        }
    }
}
