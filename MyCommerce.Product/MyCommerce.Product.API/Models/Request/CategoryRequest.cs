using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommerce.Product.API.Models.Request
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseCategoryId { get; set; }
    }
}
