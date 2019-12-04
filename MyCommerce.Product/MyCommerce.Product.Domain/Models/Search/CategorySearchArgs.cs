namespace MyCommerce.Product.Domain.Models.Search
{
    public class CategorySearchArgs
    {
        public int? Id { get; set; }
        public int? BaseCategoryId { get; set; }
        public string Name { get; set; }
    }
}