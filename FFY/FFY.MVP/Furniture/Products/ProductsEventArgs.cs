﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Furniture.Products
{
    public class ProductsEventArgs
    {
        public ProductsEventArgs(string path,
            string room, 
            string category,
            string search,
            bool rangeProvided,
            int from,
            int to)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("Path cannot be null or empty.");
            }

            this.Path = path;
            this.Room = room;
            this.Category = category;
        }

        public string Path { get; set; }

        public string Room { get; set; }

        public string Category { get; set; }

        public string Search { get; set; }

        public bool RangeProvided { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }
}
