using AutoMapper;
using MediatR;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Models.Search;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Domain.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyCommerce.Product.Application.Queries
{
    public class CategoryQuery : IRequest<IList<Category>>
    {
        public int Id { get; set; }
        public int BaseCategoryId { get; set; }
        public string Name { get; set; }
    }

    public class CategoryQueryHandler : IRequestHandler<CategoryQuery, IList<Category>>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyCategoryRepository _readonlyCategoryRepository;
        private readonly IWriteonlyCategoryRepository _writeonlyCategoryRepository;

        public CategoryQueryHandler(IMapper mapper, IReadonlyCategoryRepository readonlyCategoryRepository, IWriteonlyCategoryRepository writeonlyCategoryRepository)
        {
            _mapper = mapper;
            _readonlyCategoryRepository = readonlyCategoryRepository;
            _writeonlyCategoryRepository = writeonlyCategoryRepository;
        }

        public Task<IList<Category>> Handle(CategoryQuery request, CancellationToken cancellationToken)
        {
            var search = _mapper.Map<CategoryQuery, CategorySearchArgs>(request);
            var service = new CategoryService(_readonlyCategoryRepository, _writeonlyCategoryRepository);
            return service.Get(search);
        }
    }
}