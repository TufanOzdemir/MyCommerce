using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCommerce.Product.API.Models.Request;
using MyCommerce.Product.API.Models.Response;
using MyCommerce.Product.Application.Queries;
using MyCommerce.Product.Domain;

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
        public async Task<IActionResult> Get([FromQuery] CategoryRequest categoryRequest)
        {
            var query = _mapper.Map<CategoryRequest, CategoryQuery>(categoryRequest);
            var model = await _mediatr.Send(query);
            var result = _mapper.Map<IList<Category>, IList<CategoryViewModel>>(model);
            return Ok(result);
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
