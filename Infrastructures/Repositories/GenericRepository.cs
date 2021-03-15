using Infrastructure.Repositories.Interfaces;
using Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository : IBaseRepository
    {
        protected OnlineShopContext _patternDbContext;
        public GenericRepository(OnlineShopContext patternDbContext)
        {
            _patternDbContext = patternDbContext;
        }
       public Product AddProduct(Product prod)
        {
            _patternDbContext.Products.Add(prod);
            _patternDbContext.SaveChanges();
            return prod;
            //return _patternDbContext.Products.ToList();
        }

        public Customer CreateCustomer(Customer cust)
        {
            _patternDbContext.Customers.Add(cust);
            _patternDbContext.SaveChanges();
            return cust;
        }

        public List<Product> GetAllProducts(List<Product> result)
        {
            //_context.Products.Add(prod);
            //_context.SaveChanges();
            return result.ToList();
            //return _patternDbContext.Products.ToList();
        }

        //public List<Product> GetAllProducts()
        //{
        //    //_context.Products.Add(prod);
        //    //_context.SaveChanges();
        //    return _patternDbContext.Products.ToList();
        //}

        public List<Customer> GetCustomers()
        {
            return _patternDbContext.Customers.ToList();
        }


        
        //public List<Product> GetProducts(int id)
        //{
        //    var test = _patternDbContext.Orders.ToList();
        //    var test21 = _patternDbContext.Products.ToList();
        //    var test2 = _patternDbContext.Customers.ToList();


        //    return _patternDbContext.Find<T>();
        //}

        public void SaveChanges()
        {
            _patternDbContext.SaveChanges();
        }

       
    }
}
