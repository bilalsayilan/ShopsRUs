using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Entities.Concrete
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public User User { get; set; }
        public List<ProductInvoiceItem> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
