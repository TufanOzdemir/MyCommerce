using System;
using System.Collections.Generic;

namespace MyCommerce.Basket.API.Models.Response
{
    public class BasketViewModel : ViewModelBase
    {
        public Guid CustomerGuid { get; set; }
        public List<int> ProductIds { get; set; }
        public int BasketId { get; set; }
    }
}