using System;
using System.Collections.Generic;

namespace MyCommerce.Basket.Domain
{
    public class Basket
    {
        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }
        public List<int> ProductIds { get; set; }
    }
}