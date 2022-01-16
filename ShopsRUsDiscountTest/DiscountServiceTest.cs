using Moq;
using ShopsRUs.Common.Enums;
using ShopsRUs.Entities.Concrete;
using ShopsRUs.Repositories.Abstract;
using ShopsRUs.Services.Abstarct;
using ShopsRUs.Services.Concrete;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShopsRUsDiscountTest
{
    public class DiscountServiceTest
    {
        Mock<IDiscountRepositories> _mockDiscountRepositories;
        Invoice _invoice;
      
        public DiscountServiceTest()
        {
            _mockDiscountRepositories = new Mock<IDiscountRepositories>();
            
            _invoice = new Invoice()
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
                } ,
                TotalPrice=2000
            };
        }

        [Fact]
        public void TestEmployeeDiscount()
        {
            IDiscountService discountService = new DiscountService(_mockDiscountRepositories.Object);
            _invoice.User.UserType = UserType.Employee;
            var finalInvoiceAmount = 1450.0;
            Assert.Equal(finalInvoiceAmount, discountService.ApplyDiscount(_invoice));
        }
        [Fact]
        public void TestAffiliateDiscount()
        {
            IDiscountService discountService = new DiscountService(_mockDiscountRepositories.Object);
            _invoice.User.UserType = UserType.Affiliate;
            var finalInvoiceAmount = 1750.0;
            Assert.Equal(finalInvoiceAmount, discountService.ApplyDiscount(_invoice));
        }
        [Fact]
        public void TestOldCustomerDiscount()
        {
            IDiscountService discountService = new DiscountService(_mockDiscountRepositories.Object);
            _invoice.User.UserType = UserType.Customer;
            _invoice.User.CreateDate = new DateTime(2020, 1, 1);
            var finalInvoiceAmount = 1825.0;
            Assert.Equal(finalInvoiceAmount, discountService.ApplyDiscount(_invoice));
        }
        [Fact]
        public void TestNewCustomerDiscount()
        {
            IDiscountService discountService = new DiscountService(_mockDiscountRepositories.Object);
            _invoice.User.UserType = UserType.Customer;
            _invoice.User.CreateDate = new DateTime(2022, 1, 1);
            var finalInvoiceAmount = 1900.0;
            Assert.Equal(finalInvoiceAmount, discountService.ApplyDiscount(_invoice));
        }
    }
}
