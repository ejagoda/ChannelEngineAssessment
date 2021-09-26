using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersInProgress();
    }
}
