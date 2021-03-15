using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructures.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
