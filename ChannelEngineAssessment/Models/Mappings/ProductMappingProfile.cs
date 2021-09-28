using AutoMapper;
using ChannelEngineAssessmentLogic.Model;

namespace ChannelEngineAssessment.Models.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
