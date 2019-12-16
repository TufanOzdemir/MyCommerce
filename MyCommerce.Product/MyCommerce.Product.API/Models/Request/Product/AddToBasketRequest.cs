using System;

namespace MyCommerce.Product.API.Models.Request.Product
{
    public class AddToBasketRequest
    {
        public int ProductId { get; set; }
        public Guid CustomerGuid { get; set; }
    }
}