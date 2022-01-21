using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public interface IProductObject
    {
        int ProductId { get; set; }
        string ProductType { get; set; }
        string Brand { get; set; }
        int RAM { get; set; }
        string Storage { get; set; }
        string Model { get; set; }
        string Color { get; set; }
        string Description { get; set; }
        int Price { get; set; }
        DateTime date { get; set; }
    }
}
