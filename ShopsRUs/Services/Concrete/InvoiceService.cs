using ShopsRUs.Entities.Concrete;
using ShopsRUs.Repositories.Abstract;
using ShopsRUs.Services.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        IInvoiceRepositories _invoiceRepositories;
        public InvoiceService(IInvoiceRepositories invoiceRepositories)
        {
            _invoiceRepositories = invoiceRepositories;
        }
        public Invoice Get()
        {
          return  _invoiceRepositories.Get();
        }
    }
}
