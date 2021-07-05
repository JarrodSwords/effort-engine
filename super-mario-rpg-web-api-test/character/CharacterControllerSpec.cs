using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Application.Read;
using Xunit;

namespace SuperMarioRpg.WebApi.Test
{
    public class CharacterControllerSpec : WebApiFixture
    {
        #region Core

        public CharacterControllerSpec(WebApplicationFactory<Startup> factory) :
            base(factory, "api/characters")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task GetCharacter_ReturnsCharacter()
        {
            var character = await HttpClient.GetFromJsonAsync<Character>("Boshi");

            character.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCharacters_ReturnsCharacters()
        {
            var characters = await HttpClient.GetFromJsonAsync<IEnumerable<Character>>("");

            characters.Should().NotBeNull();
        }

        #endregion
    }
}
