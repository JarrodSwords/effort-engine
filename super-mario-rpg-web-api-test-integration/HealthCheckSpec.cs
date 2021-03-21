using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
{
    public class HealthCheckSpec : IClassFixture<WebApplicationFactory<Startup>>
    {
        #region Core

        private readonly HttpClient _httpClient;

        public HealthCheckSpec(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/healthcheck");

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
