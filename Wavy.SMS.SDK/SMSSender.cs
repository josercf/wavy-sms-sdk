using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wavy.SMS.SDK.Model;

namespace Wavy.SMS.SDK
{
    public sealed class SMSSender : ISMSSender
    {
        private readonly WavySMSOptions options;

        public SMSSender(IOptions<WavySMSOptions> options)
            => this.options = options.Value;

        public async Task<string> Send(string phoneNumber, string message)
        {
            WavySMSResponse wavyResponse;

            using (var client = CreateHttpClient())
            {
                var jsonContent = JsonSerializer.Serialize(new MessageBodyModel(phoneNumber, message));
                var data = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{options.BaseURI}/v1/send-sms", data);

                if (!response.IsSuccessStatusCode) return string.Empty;

                wavyResponse = JsonSerializer.Deserialize<WavySMSResponse>(await response.Content.ReadAsStringAsync());
            }

            return wavyResponse.Id.ToString("D");
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            AddAuthenticationHeaders(client);
            return client;
        }

        private void AddAuthenticationHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("username", options.Username);
            client.DefaultRequestHeaders.Add("authenticationtoken", options.Token);
        }
    }
}
