using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Entities.Concrete;
using ShopsRUs.Services.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class DiscountController : ControllerBase
    {
        IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpPost]
        public object ApplyDiscount(Invoice invoice)
        {
            var result = _discountService.ApplyDiscount(invoice);
            return (new { finalInvoiceAmount = result });
        }
    }
}
