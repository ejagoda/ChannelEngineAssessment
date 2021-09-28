using ChannelEngineAssessmentLogic.Configuration;
using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using ChannelEngineAssessmentLogic.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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

            var response = await client.GetAsync<ApiGetResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response.Message);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<bool> Patch<T>(string urlParams, PatchRequest<T> parameters)
        {
            var request = new RestRequest(urlParams + "?apikey=" + _apiConfig.AuthToken)
            {
                JsonSerializer = new CustomJsonSerializer()
            };
            request.AddJsonBody(new List<PatchRequest<T>> { parameters });

            var response = await client.PatchAsync<ApiPatchResponse>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(response.Message);

            return response.Success;
        }
    }
}
