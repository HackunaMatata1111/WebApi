using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.Interfaces;
using Infrastructures.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        //private readonly ILogger<OrdersController> _logger;
        private IBaseRepository _orderRepo;

        public OrdersController(IBaseRepository orderRrepo)
        {
            _orderRepo = orderRrepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Product p = new Product()
            {
                ProductName = "Pencil",
                Price = 200,
                Quantity = 10
            };

            return Ok(_orderRepo.AddProduct(p));
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                _orderRepo.AddProduct(product);
                _orderRepo.SaveChanges();

                var StatusCode = StatusCodes.Status201Created;
                var message = Ok(StatusCode);
                return message;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var matchingPeople = _orderRepo.GetCustomers().Where(p => p.Email == customer.Email);
                if (!matchingPeople.Any())
                {
                    _orderRepo.CreateCustomer(customer);
                    _orderRepo.SaveChanges();

                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(409, $"'{customer.Email}' already exists.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet("GetAllProducts")]
        //[Route("GetAllProducts")]
        public List<Product> GetAllProducts(int index,int rows)
        {
            try
            {
                using (OnlineShopContext employeeDBEntities = new OnlineShopContext())
                {
                    var STARTROWINDEX = new SqlParameter("STARTROWINDEX", index);
                    var MAXIMUMROWS = new SqlParameter("MAXIMUMROWS", rows);
                    var result= employeeDBEntities.Products.FromSqlRaw("EXECUTE dbo.GETDATA_WITHPAGING  @STARTROWINDEX,@MAXIMUMROWS", STARTROWINDEX, MAXIMUMROWS).ToList();
                    //.FromSql("EXECUTE dbo.GETDATA_WITHPAGING  @STARTROWINDEX", productCategory)
                    //.ToList();
                    return _orderRepo.GetAllProducts(result);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
