using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTransport.WebAPI.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace eTransport.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] PaymentModel payment)
        {
            var charge = new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(payment.Amount * 100), // In cents, not dollars, times by 100 to convert
                Currency = "usd", // or the currency you are dealing with
                Description = "Test description",
                Source = payment.Token
            };

            var service = new ChargeService();

            try
            {
                var api_options = new RequestOptions
                {
                    ApiKey = "sk_test_51HDqToHyu0x6Ot10sm1R9iJpFC1jrjdZpDvNXUELAC4aQ3qSWk5QExvG3LFW46ToHStIr3ZDVnlnXzZUT1Hf56ht00nVJ1OF36"
                };
                var response = service.Create(charge, api_options);

                return Ok(response.Paid);
            }
            catch (StripeException ex)
            {
                StripeError stripeError = ex.StripeError;
            }
            return Ok(true);
        }
    }
}
