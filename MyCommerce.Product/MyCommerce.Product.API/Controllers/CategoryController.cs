using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCommerce.Product.API.Models.Request;
using MyCommerce.Product.API.Models.Response;
using MyCommerce.Product.Application.Commands;
using MyCommerce.Product.Application.Queries;
using MyCommerce.Product.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] SearchCategoryRequest categoryRequest)
        {
            var query = _mapper.Map<CategoryRequest, CategoryQuery>(categoryRequest);
            var model = await _mediatr.Send(query);
            var result = _mapper.Map<IList<Category>, IList<CategoryViewModel>>(model);
            return result == null || result.Count == 0 ? NotFound("Not Found") : (IActionResult)Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] CategoryCreateRequest request)
        {
            var command = _mapper.Map<CategoryCreateRequest, CategoryCreateCommand>(request);
            var model = await _mediatr.Send(command);
            return Ok(model);
        }
    }
}