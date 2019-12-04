using MyCommerce.Product.Domain.Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCommerce.Product.Domain.Repository
{
    public interface IReadonlyCategoryRepository
    {
        Task<IList<Category>> Get(CategorySearchArgs args);
    }
}