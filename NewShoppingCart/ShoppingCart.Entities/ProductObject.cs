using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public class ProductObject:IProductObject
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public int RAM { get; set; }
        public string Storage { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime date { get; set; }
        //public List<ProductReview> ProductReviews { get; set; }
    }

    public class ProductReview
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
    }
}
