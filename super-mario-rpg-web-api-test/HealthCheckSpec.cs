using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test
{
    public class HealthCheckSpec : WebApiFixture
    {
        #region Core

        public HealthCheckSpec(WebApplicationFactory<Startup> factory)
            : base(factory, "/healthcheck")
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await HttpClient.GetAsync("");

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
