using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Application.Write;
using Xunit;

namespace SuperMarioRpg.WebApi.Test
{
    public class CharactersControllerSpec : WebApiFixture
    {
        #region Core

        public CharactersControllerSpec(WebApplicationFactory<Startup> factory) :
            base(factory, "/api/characters")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task CreateCharacter_CreatesCharacter()
        {
            var character = new CreateCharacter.Args("Mario");

            await HttpClient.PostAsJsonAsync("", character);

            var created = await HttpClient.GetFromJsonAsync<CharacterDto>("/mario");
            created.Should().NotBeNull();
        }

        [Fact]
        public async Task GetCharacter_ReturnsCharacter()
        {
            var character = await HttpClient.GetFromJsonAsync<CharacterDto>("/mario");

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
