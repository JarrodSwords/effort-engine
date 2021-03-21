using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
{
    public class CharactersControllerSpec : WebApiFixture
    {
        #region Core

        public CharactersControllerSpec(WebApplicationFactory<Startup> factory) : base(factory)
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
