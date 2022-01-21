using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBALObject
{
    public class OrderInfoObject
    {
        public string OrderId { get; set; }
        public int UserId { get; set; }
        public float Amount { get; set; }
        public string Method { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string BankTransactionID { get; set; }
        public string Address { get; set; }
    }
}
