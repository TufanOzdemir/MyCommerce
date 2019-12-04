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

namespace MyCommerce.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductRequest productRequest)
        {
            var query = _mapper.Map<ProductRequest, ProductQuery>(productRequest);
            var model = await _mediatr.Send(query);
            var result = _mapper.Map<IList<Domain.Product>, IList<ProductViewModel>>(model);
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
