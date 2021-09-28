using ChannelEngineAssessmentLogic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessmentLogic.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<string> ids);
        public Task<bool> UpdateProductStock(string id);
    }
}
