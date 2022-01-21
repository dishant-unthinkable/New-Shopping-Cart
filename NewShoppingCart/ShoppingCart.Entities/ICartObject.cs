using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public interface ICartObject
    {
         int ProductId { get; set; }
         string ProductType { get; set; }
         string Brand { get; set; }
         string Model { get; set; }
         int RAM { get; set; }
         string Storage { get; set; }
         int Price { get; set; }
         int Quantity { get; set; }
    }
}
