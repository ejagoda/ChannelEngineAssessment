using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IChannelEngineRepository _channelEngineRepo;
        public ProductService(IChannelEngineRepository channelEngine)
        {
            _channelEngineRepo = channelEngine;
        }

        public async Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<string> ids)
        {
            return await _channelEngineRepo.GetProductsByMerchantIds(ids);
        }

        public async Task<bool> UpdateProductStock(string id)
        {
            return await _channelEngineRepo.PatchProductStock(id, 25);
        }
    }
}
