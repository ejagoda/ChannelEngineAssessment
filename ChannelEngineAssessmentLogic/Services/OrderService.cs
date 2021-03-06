using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IChannelEngineRepository _channelEngineRepo;
        public OrderService(IChannelEngineRepository channelEngine)
        {
            _channelEngineRepo = channelEngine;
        }

        public async Task<CollectionOfOrders> GetOrdersInProgress()
        {
            return await _channelEngineRepo.GetOrdersInStatus(new List<OrderStatus> { OrderStatus.IN_PROGRESS });
        }
    }
}
