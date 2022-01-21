using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public class OrderListObject
    {
        public string DateOfOrder { get; set; }
        public string OrderId { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
