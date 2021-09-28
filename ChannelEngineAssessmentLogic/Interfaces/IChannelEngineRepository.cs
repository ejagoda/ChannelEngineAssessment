using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IChannelEngineRepository
    {
        public Task<CollectionOfOrders> GetOrdersInStatus(IEnumerable<OrderStatus> statuses);
        public Task<IEnumerable<Product>> GetProductsByMerchantIds(IEnumerable<string> ids);
        public Task<bool> PatchProductStock(string id, int stock);
    }
}
