using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureAdIntegrationTest
{
    public class GraphClient
    {
        //comment
        private IPublicClientApplication _msalClient;
        private string[] _scopes;

        public GraphClient(string appId, string tenantId, string[] scopes)
        {
            _scopes = scopes;

            _msalClient = PublicClientApplicationBuilder.Create(appId).WithAuthority(AzureCloudInstance.AzurePublic, new Guid(tenantId)).WithRedirectUri("http://localhost").Build();
        }
        
        public async Task<string> GetAccessToken()
        {
            var result = await _msalClient.AcquireTokenInteractive(_scopes).WithUseEmbeddedWebView(false).ExecuteAsync();

            return result.AccessToken;

        }

    }
}


//Microsoft.Identity.Client.MsalClientException : Only loopback redirect uri is supported, 
//but urn:ietf:wg:oauth:2.0:oob was found.Configure http://localhost or http://localhost:port both 
//during app registration and when you create the PublicClientApplication object.