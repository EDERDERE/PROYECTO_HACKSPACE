using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CONTACTCENTER.DTOs;
using CONTACTCENTER.Models;

namespace CONTACTCENTER.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsDetailsDTO>> GetProductsDetails(int id);
    }

    public class ProductService : IProductService
    {
        private readonly NorthwindContext _context;

        public ProductService(NorthwindContext context)
        {
            this._context = context;
        }

        // LOGICA DEL NEGOCIO 

        public async Task<IEnumerable<ProductsDetailsDTO>> GetProductsDetails(int id)
        {

            var productDetails = await (from _order_Details in _context.OrderDetails
                                        join _Products in _context.Products on _order_Details.ProductId equals _Products.ProductId
                                        where _order_Details.OrderId == id
                                        select new ProductsDetailsDTO
                                        {
                                            ProductID = _order_Details.ProductId,
                                            ProductName = _Products.ProductName,
                                            Quantity = _order_Details.Quantity,
                                            UnitPrice = _order_Details.UnitPrice,
                                            Total = (_order_Details.UnitPrice * _order_Details.Quantity)


                                        }).ToListAsync();



            return productDetails;

        }

    }
}
