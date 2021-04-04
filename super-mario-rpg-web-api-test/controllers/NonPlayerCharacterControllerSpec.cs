using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Write;
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
            var stats = new CombatStatsDto(20, 0, 20, 10, 2, 20);
            var character = new CreateCharacterDto("Mario", stats);

            var response = await HttpClient.PostAsJsonAsync("", character);

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
