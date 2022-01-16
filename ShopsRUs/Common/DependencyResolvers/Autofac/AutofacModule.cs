using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ShopsRUs.Repositories.Abstract;
using ShopsRUs.Repositories.Concrete;
using ShopsRUs.Services.Abstarct;
using ShopsRUs.Services.Concrete;

namespace ShopsRUs.Common.DependencyResolvers.Autofac
{
  
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DiscountService>().As<IDiscountService>();
            builder.RegisterType<DiscountRepositories>().As<IDiscountRepositories>();

            builder.RegisterType<InvoiceService>().As<IInvoiceService>();
            builder.RegisterType<InvoiceRepositories>().As<IInvoiceRepositories>();
        }
    }
}
