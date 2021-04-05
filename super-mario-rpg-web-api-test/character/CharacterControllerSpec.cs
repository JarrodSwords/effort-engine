using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Api;
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
            var character = await HttpClient.GetFromJsonAsync<CharacterDto>("Mario");

            character.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCharacters_ReturnsCharacters()
        {
            var characters = await HttpClient.GetFromJsonAsync<IEnumerable<CharacterDto>>("");

            characters.Should().NotBeNull();
        }

        #endregion
    }
}