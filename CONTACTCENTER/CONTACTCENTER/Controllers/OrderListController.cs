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
        private readonly IOrderStateService _iOrderStateService;

        public OrderListController(NorthwindContext context, IOrderService iOrderService, IProductService iProductService, IOrderStateService iOrderStateService)
        {
            _context = context;
            _iOrderService = iOrderService;
            _iProductService = iProductService;
            _iOrderStateService = iOrderStateService;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {

            var orderList = await _iOrderService.GetOrderList();
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

        [HttpPut("{id}", Name = "GuardarDatos")]
        public async Task<ActionResult> Put([FromBody] OrderStateDTO orderState)
        {
            if (orderState.OrderID == 0)
            {
                return BadRequest();
            }            

            try
            {
                var queryTest = await (from _Orders in _context.Orders
                                       where _Orders.OrderId == orderState.OrderID
                                       select _Orders).FirstOrDefaultAsync();

                queryTest.Confirmacion = orderState.Confirmacion;
                queryTest.FechaConfirmacion = orderState.FechaConfirmacion;
                queryTest.Comentarios = orderState.Comentarios;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return NoContent();
        }

    
    }
}
