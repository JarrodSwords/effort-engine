using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
{
    public class HealthCheckSpec : WebApiFixture
    {
        #region Core

        public HealthCheckSpec(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await HttpClient.GetAsync("/healthcheck");

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        #endregion
    }
}
