using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCommerce.Authentication.API.Models;
using MyCommerce.Authentication.Application;
using System.Threading.Tasks;

namespace MyCommerce.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatR;

        public AuthenticationController(IMapper mapper, IMediator mediatR)
        {
            _mapper = mapper;
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]LoginRequest loginRequest)
        {
            var query = _mapper.Map<LoginRequest, LoginQuery>(loginRequest);
            var token = await _mediatR.Send(query).ConfigureAwait(true);
            return Ok(token);
        }
    }
}