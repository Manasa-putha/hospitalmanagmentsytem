
using Microsoft.AspNetCore.Mvc;
using HMSFE.Models;
using HMSFE.Services;
using Microsoft.AspNetCore.Authorization;
using HMSFE.DTOS;
using HMSFE.Models.DTOS;

namespace HMSFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login/patient")]
        public async Task<IActionResult> PatientLogin([FromBody] PatientLoginDto loginDto)
        {
            var response = await _authService.PatientLoginAsync(loginDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost("login/staff")]
        public async Task<IActionResult> StaffLogin([FromBody] StaffLoginDto loginDto)
        {
            var response = await _authService.StaffLoginAsync(loginDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenAPIDTO tokenRefreshDto)
        {
            var response = await _authService.RefreshTokenAsync(tokenRefreshDto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}

