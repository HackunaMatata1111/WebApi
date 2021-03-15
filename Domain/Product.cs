using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set;}
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
