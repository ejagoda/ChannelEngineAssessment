using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IChannelEngineRepository
    {
        public Task<IEnumerable<Order>> GetOrdersInStatus(IEnumerable<OrderStatus> statuses);
    }
}
