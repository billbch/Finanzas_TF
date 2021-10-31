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
    public class Type_Interests_RateController : Controller
    {
        private readonly IType_Interest_RateService _service;

        public Type_Interests_RateController(IType_Interest_RateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Type_Interest_RateDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<Type_Interest_RateDto>> Get(int id)
        {
            return await _service.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Type_Interest_RateDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] Type_Interest_RateDto request, int id)
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