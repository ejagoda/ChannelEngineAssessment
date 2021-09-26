using ChannelEngineAssessmentLogic.Configuration;
using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Repositories
{
    public class ChannelEngineClient : IChannelEngineClient
    {
        private readonly ChannelEngineConfig _apiConfig;
        private readonly RestClient client;

        public ChannelEngineClient(IOptions<ChannelEngineConfig> config)
        {
            _apiConfig = config.Value;
            client = new RestClient(_apiConfig.BaseUrl);
        }

        public async Task<T> Get<T>(string urlParams)
        {
            var request = new RestRequest(urlParams + "apikey=" + _apiConfig.AuthToken);

            var response = await client.GetAsync<ApiResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response.Message);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
