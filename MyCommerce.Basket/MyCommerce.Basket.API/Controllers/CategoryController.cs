using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCommerce.Basket.API.Models.Request;
using MyCommerce.Basket.API.Models.Response;
using MyCommerce.Basket.Application.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCommerce.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMapper _mapper;
        public BasketController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<BasketViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] BasketRequest basketRequest)
        {
            var query = _mapper.Map<BasketRequest, BasketQuery>(basketRequest);
            var model = await _mediatr.Send(query);
            var result = _mapper.Map<IList<Domain.Basket>, IList<BasketViewModel>>(model);
            return result == null || result.Count == 0 ? NotFound("Not Found") : (IActionResult)Ok(result);
        }
    }
}