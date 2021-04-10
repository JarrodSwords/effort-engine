using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Api;
using Xunit;

namespace SuperMarioRpg.WebApi.Test
{
    public class NonPlayerCharacterControllerSpec : WebApiFixture
    {
        #region Core

        public NonPlayerCharacterControllerSpec(WebApplicationFactory<Startup> factory)
            : base(factory, "api/non-player-characters")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task CreateNonPlayerCharacter()
        {
            var character = new CreateNonPlayerCharacterArgs("Mario");

            var response = await HttpClient.PostAsJsonAsync("", character);

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
