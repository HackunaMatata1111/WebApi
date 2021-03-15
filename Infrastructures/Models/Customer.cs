using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructures.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
