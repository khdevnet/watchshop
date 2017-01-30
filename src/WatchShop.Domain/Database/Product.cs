﻿using System.Collections.Generic;
using WatchShop.Domain.Orders;

namespace WatchShop.Domain.Database
{
    internal class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}