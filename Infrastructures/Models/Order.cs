using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructures.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }

    }
}
