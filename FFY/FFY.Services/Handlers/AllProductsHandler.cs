﻿using FFY.Models;
using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Services.Handlers
{
    public class AllProductsHandler : Handler
    {
        private const string AllProductsPath = "/furniture/all";

        protected override bool CanHandle(string path, string room, string category, string search, bool rangeProvided)
        {
            return path == AllProductsPath 
                && room == null 
                && category == null
                && search == null
                && !rangeProvided;
        }

        protected override IEnumerable<Product> Handle(IProductsService productsService, string room, string category, string search, bool rangeProvided, int from, int to)
        {
            return productsService.GetProducts();
        }
    }
}
