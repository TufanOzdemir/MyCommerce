﻿using System;

namespace MyCommerce.Basket.Domain
{
    public class Basket
    {
        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }
    }
}