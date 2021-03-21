using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
{
    public class CharacterControllerSpec : WebApiFixture
    {
        #region Core

        public CharacterControllerSpec(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task GetCharacters_Exists()
        {
            var response = await HttpClient.GetAsync("/api/characters");

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
