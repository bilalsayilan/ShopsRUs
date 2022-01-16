using ShopsRUs.Common.Enums;
using ShopsRUs.Entities.Concrete;
using ShopsRUs.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Repositories.Concrete
{
    public class InvoiceRepositories : IInvoiceRepositories
    {
        public Invoice Get()
        {
           var invoice = new Invoice()
            {
                Id = 1,
                InvoiceDate = new DateTime(2022, 1, 1),
                Products = new List<ProductInvoiceItem>()
                    {
                        new ProductInvoiceItem()
                        {
                            Id=1,
                            Price=500.0,
                            UnitPrice=500.0,
                            Quantity=1,
                            ProductType=ProductType.Cosmetic
                        },
                         new ProductInvoiceItem()
                        {
                            Id=2,
                            Price=1000.0,
                            UnitPrice=500.0,
                            Quantity=2,
                            ProductType=ProductType.Electronic
                        },
                         new ProductInvoiceItem()
                        {
                            Id=2,
                            Price=500.0,
                            UnitPrice=250.0,
                            Quantity=2,
                            ProductType=ProductType.Groceries
                        }
                    },
                User = new User()
                {
                    Id = 1,
                    CreateDate = new DateTime(2020, 1, 1),
                    Name = "Bilal",
                    Surname = "Sayılan",
                    UserType = UserType.Employee
                },
                TotalPrice = 2000
            };
            return invoice;
        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
