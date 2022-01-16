using ShopsRUs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Entities.Concrete
{
    public class ProductInvoiceItem
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public double  UnitPrice { get; set; }
        public int Quantity { get; set; }
        public ProductType ProductType { get; set; }
    }
}
