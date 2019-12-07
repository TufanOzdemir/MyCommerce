using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyCommerce.Product.Domain;
using MyCommerce.Product.Domain.Repository;
using MyCommerce.Product.Domain.Services;

namespace MyCommerce.Product.Application.Commands
{
    public class CategoryCreateCommand : IRequest<bool>
    {
        public int? BaseCategoryId { get; set; }
        public string Name { get; set; }
    }

    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IReadonlyCategoryRepository _readonlyCategoryRepository;
        private readonly IWriteonlyCategoryRepository _writeonlyCategoryRepository;

        public CategoryCreateCommandHandler(IMapper mapper, IReadonlyCategoryRepository readonlyCategoryRepository, IWriteonlyCategoryRepository writeonlyCategoryRepository)
        {
            _mapper = mapper;
            _readonlyCategoryRepository = readonlyCategoryRepository;
            _writeonlyCategoryRepository = writeonlyCategoryRepository;
        }

        public async Task<bool> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<CategoryCreateCommand, Category>(request);
            var service = new CategoryService(_readonlyCategoryRepository, _writeonlyCategoryRepository);
            await service.Create(model);
            return true;
        }
    }
}