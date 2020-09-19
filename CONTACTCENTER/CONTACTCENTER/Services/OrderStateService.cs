using CONTACTCENTER.DTOs;
using CONTACTCENTER.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTACTCENTER.Services
{

    public interface IOrderStateService
    {

        //void GuardarDatos(OrderStateDTO orderState);
    }

    public class OrderStateService : IOrderStateService
    {

        private readonly NorthwindContext _context;



        public OrderStateService(NorthwindContext context)
        {
            this._context = context;
        }


        //public  void GuardarDatos(OrderStateDTO orderState)
        //{
            
        //    try
        //    {

        //        var queryTest = await (from _Orders in _context.Orders
        //                               where _Orders.OrderId == orderState.OrderID
        //                               select _Orders).FirstOrDefaultAsync();

        //        queryTest.Confirmacion = orderState.Confirmacion;
        //        queryTest.FechaConfirmacion = orderState.FechaConfirmacion;
        //        queryTest.Comentarios = orderState.Comentarios;

        //        _context.SaveChanges();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }          

        //}
    }
}
