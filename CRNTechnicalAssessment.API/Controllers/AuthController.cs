using CRNTechnicalAssessment.Application.DTOs;
using CRNTechnicalAssessment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRNTechnicalAssessment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
           

            var result = await _userService.LoginAsync(request);

            if (result == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid Username or Password"
                });
            }

            return Ok(result);
        }
    }
}