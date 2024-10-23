using Microsoft.AspNetCore.Mvc;
using Sunbeam_Backoffice.Prototype.Services;

namespace Sunbeam_Backoffice.Prototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("get-by-email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email must be provided.");
            }

            var result = await _userService.GetUserByEmailAsync(email);

            if (result.IsSuccess)
            {
                return Ok(result.Data); 
            }
            else
            {
                return StatusCode(result.StatusCode, result.ErrorMessage);
            }
        }
    }
}
