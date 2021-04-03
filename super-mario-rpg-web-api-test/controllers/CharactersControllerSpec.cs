using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write;
using Xunit;
using CombatStatsDto = SuperMarioRpg.Application.Write.CombatStatsDto;

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
            var stats = new CombatStatsDto(20, 0, 20, 10, 2, 20);
            var character = new CreateCharacterDto("Mario", stats);

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
