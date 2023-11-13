using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yad2_back.Models;
using yad2_back.Models.models_for_router;
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
        public async Task<IActionResult> IsEmailAlreadyExist([FromBody] CheckEmailModel model)
        {
            return Ok(await _authRepository.IsEmailAlreadyExist(model.Email));
        }
        [HttpPost("")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel signupModel)
        {
            UserDTOModel? result=await _authRepository.SignUp(signupModel);
            if (result == null)
                return Unauthorized("this email already exist");
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] SigninModel signinModel)
        {
            UserDTOModel? result = await _authRepository.SignIn(signinModel);
            if (result == null)
                return Unauthorized("username or password are incorrect");
            return Ok(result);
        }
        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetUser()
        {
            var  forDaniel= User.Identity?.Name;
            string? userId = User.Claims.ToList()[0].Value;
            if (String.IsNullOrWhiteSpace(userId))
                return Unauthorized("you didn't send a token");
            UserDTOModel? res = await _authRepository.GetUserById(userId);
            if (res == null)
                return Unauthorized("this token is fake");
            return Ok(res);
        }
    }
}
