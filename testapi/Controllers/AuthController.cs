using Microsoft.AspNetCore.Mvc;
using testapi.DTO;
using testapi.Services;
// using Serilog;

namespace testapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<SuperHeroController> _logger;
        private readonly IAdminService _adminService;
        public AuthController(IAdminService adminService, ILogger<SuperHeroController> logger)
        {
            _logger = logger;
            _adminService = adminService;

        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister user)
        {


            var _user = await _adminService.Register(user);
            if (_user == null)
            {
                return BadRequest(new { Message = "User already exists." });
            }
            return Ok(new { Message = "User created successfully." });
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login(string user, string password)
        {


            var _user = await _adminService.Login(user, password);
            if (_user == null)
            {
                return Unauthorized();
            }
            return Ok(_user.Token);
        }
        

    }
}