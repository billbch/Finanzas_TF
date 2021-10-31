using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Cartera.Services;

namespace Cartera.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    //[ApiVersion("1.0")]
    public class UsersControllerConfirmation : ControllerBase
    {
        private IUserServiceConfirmation _userService;

        public UsersControllerConfirmation(IUserServiceConfirmation userService)
        {
            _userService = userService;
            /* var payments = await _PaymentService.ListByServicesProviderIdAsync(providerId);*/
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }*/
    }
}