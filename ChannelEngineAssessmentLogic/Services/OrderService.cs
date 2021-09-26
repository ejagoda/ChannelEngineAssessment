using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IChannelEngineRepository _channelEngineService;
        public OrderService(IChannelEngineRepository channelEngine)
        {
            _channelEngineService = channelEngine;
        }

        public async Task<IEnumerable<Order>> GetOrdersInProgress()
        {
            return await _channelEngineService.GetOrdersInStatus(new List<OrderStatus> { OrderStatus.IN_PROGRESS });
        }
    }
}
