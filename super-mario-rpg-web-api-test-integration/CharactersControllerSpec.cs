using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using SuperMarioRpg.Domain.Combat;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
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
        public async Task Get_ReturnsCharacters()
        {
            var characters = await HttpClient.GetFromJsonAsync<IEnumerable<Character>>("");

            characters.Should().NotBeNull();
        }

        #endregion
    }
}
