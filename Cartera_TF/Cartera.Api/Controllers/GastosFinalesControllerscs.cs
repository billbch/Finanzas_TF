using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cartera.Services;
using Cartera.DTO;

namespace Cartera.Controllers
{
    [Route("api/[controller]")]
    //[ApiVersion("1.0")]
    [ApiController]
    public class GastosFinalesController : Controller
    {
        private readonly IGastosFinalesService _service;

        public GastosFinalesController(IGastosFinalesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<GastosFinalesDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<GastosFinalesDto>> Get(int id)
        {
            return await _service.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] GastosFinalesDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] GastosFinalesDto request, int id)
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
