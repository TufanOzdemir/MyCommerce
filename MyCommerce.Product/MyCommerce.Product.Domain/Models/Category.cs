namespace MyCommerce.Product.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? BaseCategoryId { get; set; }
    }
}