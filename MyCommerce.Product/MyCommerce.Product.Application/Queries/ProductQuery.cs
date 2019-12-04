using AutoMapper;
using MediatR;
using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Product.Application.Queries
{
    public class ProductQuery : IRequest<IList<Domain.Product>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }

    public class ProductQueryHandler : IRequestHandler<ProductQuery, IList<Domain.Product>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyProductRepository _readonlyProductRepository;
        private readonly IWriteonlyProductRepository _writeonlyProductRepository;

        public ProductQueryHandler(IMapper mapper, IReadonlyProductRepository readonlyProductRepository, IWriteonlyProductRepository writeonlyProductRepository)
        {
            _mapper = mapper;
            _readonlyProductRepository = readonlyProductRepository;
            _writeonlyProductRepository = writeonlyProductRepository;
        }

        public Task<IList<Domain.Product>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            var search = _mapper.Map<ProductQuery, ProductSearchArgs>(request);
            var service = new ProductService(_readonlyProductRepository, _writeonlyProductRepository);
            return service.Get(search);
        }
    }
}