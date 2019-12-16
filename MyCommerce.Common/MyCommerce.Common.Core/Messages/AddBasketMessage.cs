using System;
using System.Collections.Generic;

namespace MyCommerce.Common.Core
{
    public class AddBasketMessage
    {
        public Guid TransactionId { get; set; }
        public string IpAddress { get; set; }
        public int Id { get; set; }
        public Guid CustomerGuid { get; set; }
    }
}