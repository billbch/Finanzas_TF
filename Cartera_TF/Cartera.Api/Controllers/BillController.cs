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
    public class BillController : Controller
    {
        private readonly IBillService _service;

        public BillController(IBillService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<BillDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<BillDto>> Get(int id)
        {
            return await _service.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] BillDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] BillDto request, int id)
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
