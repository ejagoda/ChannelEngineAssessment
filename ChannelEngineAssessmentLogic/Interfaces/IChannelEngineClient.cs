using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IChannelEngineClient
    {
        public Task<T> Get<T>(string urlParams);
    }
}
