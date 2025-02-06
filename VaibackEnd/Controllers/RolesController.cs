using Microsoft.AspNetCore.Mvc;
using VaibackEnd.Models;
using VaibackEnd.Services;

namespace VaibackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RolesService _rolesService;

        public RolesController(RolesService rolesService)
        {
            _rolesService = rolesService;
        }

        /// <summary>
        /// Returns current user role.
        /// </summary>
        /// <param name="user"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("currentRole")]
        public async Task<IActionResult> GetCurrentUserRole([FromQuery] User user)
        {
            var foundUser = _rolesService._rolesContext.Users.Find(user.Id);
            if (foundUser == null)
            {
                return NotFound("User not found");
            }

            var role = _rolesService.GetCurrentUserRole(foundUser);
            return Ok(role);
        }

        /// <summary>
        /// Edits role for user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRole"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("editRole")]
        public IActionResult EditUserRole([FromQuery] int userId, [FromQuery] Role userRole)
        {
            var user = _rolesService._rolesContext.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _rolesService.EditUserRole(userId, userRole);
            return NoContent();
        }
    }
}
