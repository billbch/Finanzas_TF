using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Cartera.Services;
using System.Threading.Tasks;
using Cartera.DTO;
using System.Collections.Generic;

namespace Cartera.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : Controller
    {
           private readonly IUserService _service;

           public UserController(IUserService service)
           {
               _service = service;
           }

           [HttpGet]
           public async Task<IEnumerable<UserDto>> List()
           {
               return await _service.GetCollection();
           }

           [HttpGet]
           [Route("{id:int}")]
           public async Task<ResponseDto<UserDto>> Get(int id)
           {
               return await _service.GetItem(id);
           }

           [HttpPost]
           public async Task Post([FromBody] UserDto request)
           {
               await _service.Create(request);
           }

           [HttpPut]
           [Route("{id:int}")]
           public async Task Put([FromBody] UserDto request, int id)
           {
               await _service.Update(id, request);

           }

           [HttpDelete]
           [Route("{id:int}")]
           public async Task Delete(int id)
           {
               await _service.Delete(id);

           }

    }
}
