using Infrastructures.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        

        void SaveChanges();
        //Product AddProduct(Product prod);

        Product AddProduct(Product prod);

        Customer CreateCustomer(Customer cust);
        //List<Product> GetAllProducts();
        List<Product> GetAllProducts(List<Product> result);
        List<Customer> GetCustomers();

        //To create a product
        //Product AddProduct(Product prod);
    }
}
