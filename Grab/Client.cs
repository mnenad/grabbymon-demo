using System;
using System.Net.Http;
using Steeltoe.Discovery.Client;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public async Task<long> GetLastAsync(Guid monsterId) {
            long last = -1;

            using (HttpClient client = this.CreateHttpClient()) 
            {
                var result = await client.GetStringAsync(GRAB_SERVICE_URL_BASE + monsterId.ToString() + "/latest?count=1");
                List<Dictionary<string, string>> history = 
                    JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(result);

                last = Int64.Parse(history[0]["at"]);
            }

            return last;
        }

        public async Task<int> CountAsync(Guid monsterId) {
            int count = -1;

            using (HttpClient client = this.CreateHttpClient()) 
            {
                var result = await client.GetStringAsync(GRAB_SERVICE_URL_BASE + monsterId.ToString() + "/count");
                count = System.Int32.Parse(result.ToString());
            }

            return count;
        }

        public async void GrabAsync(Guid monsterId)
        {
            using (HttpClient client = this.CreateHttpClient()) 
            {
                HttpContent content = new StringContent("");
                await client.PostAsync(GRAB_SERVICE_URL_BASE + monsterId.ToString(), content);
            }
        }
    }
} 
