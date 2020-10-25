using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTransport.WebAPI.Database
{
    public class PaymentModel
    {
        public int PaymentModelID { get; set; }
        public string Token { get; set; }
        public decimal Amount { get; set; }
    }
}
