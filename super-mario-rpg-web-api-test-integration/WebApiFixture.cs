using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SuperMarioRpg.WebApi.Test.Integration
{
    public abstract class WebApiFixture : IClassFixture<WebApplicationFactory<Startup>>
    {
        #region Creation

        protected WebApiFixture(WebApplicationFactory<Startup> factory)
        {
            HttpClient = factory.CreateDefaultClient();
        }

        #endregion

        #region Protected Interface

        protected HttpClient HttpClient { get; }

        #endregion
    }
}