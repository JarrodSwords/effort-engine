using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Effort.Domain.Messages;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Api;
using SuperMarioRpg.Application.Write;
using Xunit;

namespace SuperMarioRpg.WebApi.Test
{
    public class CharacterControllerSpec : WebApiFixture
    {
        #region Core

        public CharacterControllerSpec(WebApplicationFactory<Startup> factory) :
            base(factory, "api/characters")
        {
            var seeder =
                factory.Services.GetService(typeof(ICommandHandler<SeedNonPlayerCharacters>)) as
                    ICommandHandler<SeedNonPlayerCharacters>;

            seeder.Handle(new SeedNonPlayerCharacters());
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task GetCharacter_ReturnsCharacter()
        {
            var character = await HttpClient.GetFromJsonAsync<CharacterDto>("Toad");

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
