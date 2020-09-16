using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CONTACTCENTER.DTOs;
using CONTACTCENTER.Models;
using CONTACTCENTER.Services;
using Microsoft.AspNetCore.Cors;

namespace CONTACTCENTER.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {

        private readonly NorthwindContext _context;
        private readonly IOrderService _iOrderService;
        private readonly IProductService _iProductService;

        public OrderListController(NorthwindContext context, IOrderService iOrderService , IProductService  iProductService)
        {
            _context = context;
            _iOrderService = iOrderService;
            _iProductService = iProductService;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {

           var orderList= await _iOrderService.GetOrderList();
           return Ok(orderList);
            }

        // GET: api/OrderList/5

        [Route("listProduct/{id:int}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetails(int id)
        {
            var productDetails = await _iProductService.GetProductsDetails(id);
            return Ok(productDetails);
        }

    }
}
