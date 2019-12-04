﻿using System.Collections.Generic;

namespace MyCommerce.Product.API.Models.Response
{
    public class ViewModelBase
    {
        public List<Link> Links { get; set; }
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Url { get; set; }
    }
}