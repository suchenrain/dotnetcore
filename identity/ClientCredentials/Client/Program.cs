using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private enum GrantType
        {
            ClientCredentials = 1,
            ResourceOwnerPassword = 2
        }
        static void Main(string[] args) => MainAsync(2).GetAwaiter().GetResult();

        private static async Task MainAsync(int mode)
        {
            //discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            TokenClient tokenClient = null;
            TokenResponse tokenResponse = null;

            //request token
            switch ((GrantType)mode)
            {
                case GrantType.ClientCredentials:
                    tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
                    tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                    break;
                case GrantType.ResourceOwnerPassword:
                    tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
                    tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");
                    break;
                default:
                    tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
                    tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                    break;
            }


            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            //call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
