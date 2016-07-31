using System;
using System.Net.Http;
using SteelToe.Discovery.Client;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Grab 
{
    public class Client : IClient
    {
        private DiscoveryHttpClientHandler handler;
        private const string GRAB_SERVICE_URL_BASE = "http://grabservice/api/grabs/";

        public Client(IDiscoveryClient client) {
            this.handler = new DiscoveryHttpClientHandler(client);
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(this.handler, false);
        } 

        public int Count(Guid monsterId) {
            int count = -1;

            using (HttpClient client = this.CreateHttpClient()) 
            {
                var result = client.GetStringAsync(GRAB_SERVICE_URL_BASE + monsterId.ToString() + "/count").GetAwaiter().GetResult();
                count = System.Int32.Parse(result.ToString());
            }

            return count;
        }

        public void Grab(Guid monsterId)
        {
            using (HttpClient client = this.CreateHttpClient()) 
            {
                HttpContent content = new StringContent("");
                client.PostAsync(GRAB_SERVICE_URL_BASE + monsterId.ToString(), content).GetAwaiter().GetResult();
            }
        }
    }
} 
