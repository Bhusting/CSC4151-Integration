using AzureAdIntegrationTest;
using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class MSALIntegrationTest
    {
        private readonly string clientId = "f1557b6b-a3c9-4b16-baf6-63525de288e9";
        private readonly string tenantId = "978584d1-963c-47dd-b0d3-af4a4375f080";

        [Fact]
        public async Task MSALTokenExample()
        {
            var client = new GraphClient(clientId, tenantId, new string[] { "user.read" });

            var token = await client.GetAccessToken();

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44353");

            var res = await httpClient.GetAsync("Ping");

        }
    }
}
