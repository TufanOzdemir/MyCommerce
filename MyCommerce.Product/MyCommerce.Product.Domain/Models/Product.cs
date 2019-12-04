using System.Collections.Generic;

namespace MyCommerce.Product.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public List<string> ImageUrls { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}