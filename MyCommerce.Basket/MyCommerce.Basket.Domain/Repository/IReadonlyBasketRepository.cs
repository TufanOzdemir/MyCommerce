using MyCommerce.Basket.Domain.Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCommerce.Basket.Domain.Repository
{
    public interface IReadonlyBasketRepository
    {
        Task<IList<Basket>> Get(BasketSearchArgs args);
    }
}