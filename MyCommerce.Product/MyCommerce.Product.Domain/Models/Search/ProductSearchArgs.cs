namespace MyCommerce.Product.Domain.Models.Search
{
    public class ProductSearchArgs
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}