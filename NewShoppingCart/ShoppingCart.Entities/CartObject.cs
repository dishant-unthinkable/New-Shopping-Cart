using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public class CartObject:ICartObject
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int RAM { get; set; }
        public string Storage { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
