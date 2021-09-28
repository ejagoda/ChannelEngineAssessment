using ChannelEngineAssessmentLogic.Model;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IChannelEngineClient
    {
        public Task<T> Get<T>(string urlParams);
        public Task<bool> Patch<T>(string urlParams, PatchRequest<T> parameters);
    }
}
