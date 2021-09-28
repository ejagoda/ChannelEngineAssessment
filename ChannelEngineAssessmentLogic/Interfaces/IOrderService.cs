using ChannelEngineAssessmentLogic.Model;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IOrderService
    {
        Task<CollectionOfOrders> GetOrdersInProgress();
    }
}
