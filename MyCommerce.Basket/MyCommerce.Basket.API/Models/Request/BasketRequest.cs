using System;

namespace MyCommerce.Basket.API.Models.Request
{
    public class BasketRequest
    {
        public int? Id { get; set; }
        public Guid? CustomerGuid { get; set; }
    }
}