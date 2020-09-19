using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CONTACTCENTER.Models;
using CONTACTCENTER.Util;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CONTACTCENTER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly NorthwindContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        [HttpGet]
        public async Task<ActionResult<PaginadorGenerico<Customers>>> GetCustomers(string buscar,
                                                                                 string orden = "CustomerID",
                                                                                 string tipo_orden = "ASC",
                                                                                 int pagina = 1,
                                                                                 int registros_por_pagina = 10)
        {
           

           // var listCustomers = await _context.Customers.ToListAsync();

           // return listCustomers;


            List<Customers> _Customers;
            PaginadorGenerico<Customers> _PaginadorCustomers;

            ////////////////////////
            // FILTRO DE BÚSQUEDA //
            ////////////////////////
            // Recuperamos el 'DbSet' completo
            _Customers = _context.Customers.ToList();

            // Filtramos el resultado por el 'texto de búqueda'
            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    _Customers = _Customers.Where(x => x.ContactName.Contains(item) ||
                                                  x.CompanyName.Contains(item) ||
                                                  x.Phone.Contains(item))
                                                  .ToList();
                }
            }


            /////////////////////////////
            // ORDENACIÓN POR COLUMNAS //
            /////////////////////////////
            switch (orden)
            {
                case "CustomerID":
                    if (tipo_orden.ToLower() == "desc")
                        _Customers = _Customers.OrderByDescending(x => x.CustomerId).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Customers = _Customers.OrderBy(x => x.CustomerId).ToList();
                    break;

                case "CompanyName":
                    if (tipo_orden.ToLower() == "desc")
                        _Customers = _Customers.OrderByDescending(x => x.CompanyName).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Customers = _Customers.OrderBy(x => x.CompanyName).ToList();
                    break;

                case "ContactName":
                    if (tipo_orden.ToLower() == "desc")
                        _Customers = _Customers.OrderByDescending(x => x.CompanyName).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Customers = _Customers.OrderBy(x => x.CompanyName).ToList();
                    break;

                // ...
                // Aquí el resto de los campos de la tabla por los que ordenar.
                // ...

                default:
                    if (tipo_orden.ToLower() == "desc")
                        _Customers = _Customers.OrderByDescending(x => x.CustomerId).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Customers = _Customers.OrderBy(x => x.CustomerId).ToList();
                    break;
            }


            ///////////////////////////
            // SISTEMA DE PAGINACIÓN //
            ///////////////////////////
            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            // Número total de registros de la tabla Customers
            _TotalRegistros = _Customers.Count();
            // Obtenemos la 'página de registros' de la tabla Customers
            _Customers = _Customers.Skip((pagina - 1) * registros_por_pagina)
                                             .Take(registros_por_pagina)
                                             .ToList();
            // Número total de páginas de la tabla Customers
            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorCustomers = new PaginadorGenerico<Customers>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_orden,
                Resultado = _Customers
            };

            return _PaginadorCustomers;


        }
    }
}
