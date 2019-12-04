using System.Collections.Generic;

namespace MyCommerce.Product.API.Models.Response
{
    public class ProductViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public List<string> ImageUrls { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}