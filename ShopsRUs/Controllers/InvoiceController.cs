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
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class InvoiceController : ControllerBase
    {
        IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public Invoice GetInvoice()
        {
            return _invoiceService.Get();
        }
    }
}
