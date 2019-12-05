using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.Application.Configuration
{
    public interface IConfigResolver
    {
        T Resolve<T>() where T : BaseConfig, new();
    }
}
