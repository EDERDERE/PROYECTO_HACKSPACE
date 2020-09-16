using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CONTACTCENTER.DTOs;
using CONTACTCENTER.Models;
using Microsoft.EntityFrameworkCore;



namespace CONTACTCENTER.Services
{

    public interface  IOrderService {

        Task<IEnumerable<OrderListDTO>> GetOrderList();
    }

    public class OrderService : IOrderService
    {
        private readonly NorthwindContext _context;



        public OrderService(NorthwindContext context)
        {
            this._context = context;
        }


        // LOGICA DEL NEGOCIO 

        public async Task<IEnumerable<OrderListDTO>> GetOrderList()
        {

            var orderList = await (from _Orders in _context.Orders
                                   join _Customers in _context.Customers on _Orders.CustomerId equals _Customers.CustomerId
                                   where _Orders.Confirmacion == 3
                                   orderby _Orders.OrderDate descending
                                   
                                   select new OrderListDTO
                                   {
                                       OrderID = _Orders.OrderId,
                                       OrderDate =_Orders.OrderDate,
                                       ContactName = _Customers.ContactName,
                                       Phone = _Customers.Phone
                                   }).ToListAsync();
            return orderList;

        }          


    }
}
