using AutoMapper;
using ChannelEngineAssessment.Models;
using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetOrdersInProgress();
            var viewModel = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(result);

            return View(viewModel);
        }
    }
}
