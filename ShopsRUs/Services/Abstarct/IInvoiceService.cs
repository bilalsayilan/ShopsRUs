﻿using ShopsRUs.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.Services.Abstarct
{
    public interface IInvoiceService
    {
        Invoice Get();
    }
}
