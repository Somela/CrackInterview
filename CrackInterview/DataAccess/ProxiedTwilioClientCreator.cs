using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Twilio.Clients;

namespace CrackInterview
{
    public interface IProxiedTwilioClientCreator
    {
        TwilioRestClient GetClient();
    }
    public class ProxiedTwilioClientCreator : IProxiedTwilioClientCreator
    {
        private readonly IConfiguration _configuration;
        private static HttpClient _httpClient;

        public ProxiedTwilioClientCreator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void CreateHttpClient()
        {
            var proxyUrl = _configuration.GetSection("Twilio:ProxyServerUrl").Value;
            var handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(proxyUrl),
                UseProxy = true
            };

            _httpClient = new HttpClient(handler);
            var byteArray = Encoding.Unicode.GetBytes(
               _configuration.GetSection("Twilio:ProxyUsername").Value + ":" +
                _configuration.GetSection("Twilio:ProxyPassword").Value
            );

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(byteArray));
        }

        public TwilioRestClient GetClient()
        {
            var accountSid = _configuration.GetSection("Twilio:TwilioAccountSid").Value;
            var authToken = _configuration.GetSection("Twilio:TwilioAuthToken").Value;
            CreateHttpClient();
            if (_httpClient == null)
            {
                CreateHttpClient();
            }

            var twilioRestClient = new TwilioRestClient(
                accountSid,
                authToken,
                httpClient: new Twilio.Http.SystemNetHttpClient(_httpClient)
            );

            return twilioRestClient;
        }
    }
}