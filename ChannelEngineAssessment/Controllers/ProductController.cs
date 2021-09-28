using AutoMapper;
using ChannelEngineAssessment.Models;
using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ChannelEngineAssessment.Controllers
{
    public class ProductController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IOrderService orderService, IMapper mapper, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetOrdersInProgress();
            var topProducts = result.GetTopSoldProductsIds(5);
            var products = await _productService.GetProductsByIds(topProducts.Keys);
            var viewModel = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            foreach(var model in viewModel)
            {
                var product = topProducts.FirstOrDefault(p => p.Key.Equals(model.MerchantProductNo));
                model.TotalQuantitySold = product.Value;
            }
            viewModel = viewModel.OrderByDescending(m => m.TotalQuantitySold);

            return View(viewModel);
        }
    }
}
