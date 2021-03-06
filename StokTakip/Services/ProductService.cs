﻿using StokTakip.Entities.Concrete;
using StokTakip.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(StokContext stokContext) : base(stokContext)
        {
        }
    }
}
