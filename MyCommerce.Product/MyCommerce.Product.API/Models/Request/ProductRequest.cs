namespace MyCommerce.Product.API.Models.Request
{
    public class ProductRequest
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}