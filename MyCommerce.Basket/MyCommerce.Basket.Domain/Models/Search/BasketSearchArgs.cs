using System;

namespace MyCommerce.Basket.Domain.Models.Search
{
    public class BasketSearchArgs
    {
        public int? Id { get; set; }
        public Guid? CustomerGuid { get; set; }
    }
}