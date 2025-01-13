using Microsoft.AspNetCore.Mvc;
using VaibackEnd.Models;

namespace VaibackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogginController : ControllerBase
    {
        private readonly LogginService _logginService;

        public LogginController(LogginService logginService)
        {
            _logginService = logginService;
        }

        /// <summary>
        /// Returns logged in user.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("getLoggedUser")]
        public ActionResult<Loggin> GetLoggedInUser()
        {
            var loggin = _logginService.GetLoggedInUser();
            if (loggin == null)
            {
                return NotFound("No user is currently logged in.");
            }
            return Ok(loggin);
        }

        /// <summary>
        /// Adds logged in user.
        /// </summary>
        /// <param name="user"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("logInUser")]
        public ActionResult<Loggin> AddLoggedInUser([FromBody] User user)
        {
            try
            {
                var loggin = _logginService.AddLoggedInUser(user);
                return CreatedAtAction(nameof(GetLoggedInUser), new { id = loggin.user.Id }, loggin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deltes logged in user.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("logOutUser")]
        public ActionResult DeleteLoggedInUser()
        {
            var result = _logginService.DeleteLoggedInUser();
            if (!result)
            {
                return NotFound("No user is currently logged in.");
            }
            return NoContent();
        }
    }
}
