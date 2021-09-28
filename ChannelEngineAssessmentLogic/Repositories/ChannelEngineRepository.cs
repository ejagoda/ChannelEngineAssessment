using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace ChannelEngineAssessmentLogic.Repositories
{
    public class ChannelEngineRepository : IChannelEngineRepository
    {
        private readonly IChannelEngineClient _client;

        public ChannelEngineRepository(IChannelEngineClient client)
        {
            _client = client;
        }
        
        public async Task<CollectionOfOrders> GetOrdersInStatus(IEnumerable<OrderStatus> statuses)
        {
            var urlBuilder = new StringBuilder("orders?");
            foreach (var status in statuses)
                urlBuilder.Append("statuses=").Append(status.ToString()).Append("&");
            return await _client.Get<CollectionOfOrders>(urlBuilder.ToString());
        }

        public async Task<IEnumerable<Product>> GetProductsByMerchantIds(IEnumerable<string> ids)
        {
            var urlBuilder = new StringBuilder("products?");
            foreach (var id in ids)
                urlBuilder.Append("merchantProductNoList=").Append(id).Append("&");
            return await _client.Get<IEnumerable<Product>>(urlBuilder.ToString());
        }
    }
}
