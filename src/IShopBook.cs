﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    internal interface IShopBook : IBook
    {
        public decimal Price { get; set; }
    }
}