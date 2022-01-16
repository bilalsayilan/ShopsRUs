using ShopsRUs.Entities.Concrete;
using ShopsRUs.Repositories.Abstract;
using ShopsRUs.Services.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopsRUs.Common.Enums;
namespace ShopsRUs.Services.Concrete
{
    public class DiscountService : IDiscountService
    {
        IDiscountRepositories _discountRepositories;
        public DiscountService(IDiscountRepositories discountRepositories)
        {
            _discountRepositories = discountRepositories;
        }
        double IDiscountService.ApplyDiscount(Invoice invoice)
        {
            var discount = 0.0;
            var discountProductsPrice = invoice.Products.Where(w => w.ProductType != ProductType.Groceries).Sum(s => s.Price);
  
            switch (invoice.User.UserType)
            {
                case UserType.Customer:
                  var customerTimeSpan = invoice.InvoiceDate - invoice.User.CreateDate;
                    if (customerTimeSpan.TotalDays > 730)
                    {
                        discount = CalculateDiscountCustomer(discountProductsPrice);
                    }
                    break;
                case UserType.Affiliate:
                    discount = CalcuateDiscountAffiliate(discountProductsPrice);
                    break;
                case UserType.Employee:
                        discount = CalcuateDiscountEmployee(discountProductsPrice);
                    break;
            }

            discount += CalcuateDiscountMod(invoice);

            return invoice.TotalPrice - discount;
        }

        private double CalculateDiscountCustomer(double discountProductsPrice)
        {
            var result = discountProductsPrice * 0.05;
            return result;
        }

        private double CalcuateDiscountAffiliate(double discountProductsPrice)
        {
            var result = discountProductsPrice * 0.1;
            return result;
        }

        private double CalcuateDiscountEmployee(double discountProductsPrice)
        {
            var result = discountProductsPrice * 0.3;
            return result;
        }

        private double CalcuateDiscountMod(Invoice invoice)
        {
            var result = (int)invoice.TotalPrice / 100 * 5;
            return result;
        }


    }
}
