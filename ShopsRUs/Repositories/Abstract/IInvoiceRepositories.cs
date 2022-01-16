using ShopsRUs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Repositories.Abstract
{
    public interface IInvoiceRepositories
    {
        List<Invoice> GetAll();
        Invoice Get();
    }
}
