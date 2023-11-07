using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yad2_back.Repositories;

namespace yad2_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("check-email")]
        public async Task<IActionResult> IsEmailAlreadyExist([FromBody] string email)
        {
            return Ok(await _authRepository.IsEmailAlreadyExist(email));
        }
    }
}
