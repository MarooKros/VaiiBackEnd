using Microsoft.AspNetCore.Mvc;
using VaibackEnd.Models;
using VaibackEnd.Services;

namespace VaibackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {
        private readonly PictureService _pictureService;

        public PicturesController(PictureService pictureService)
        {
            _pictureService = pictureService;
        }

        /// <summary>
        /// Create a new picture.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("createPicture")]
        public async Task<ActionResult<Picture>> CreatePicture([FromBody] Picture picture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdPicture = await _pictureService.CreatePictureAsync(picture);
                return CreatedAtAction(nameof(GetPictureById), new { id = createdPicture.Id }, createdPicture);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get a picture by Id.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getPictureById/{id}")]
        public async Task<ActionResult<Picture>> GetPictureById(int id)
        {
            try
            {
                var picture = await _pictureService.GetPictureByIdAsync(id);
                return Ok(picture);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Get all pictures.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("getAllPictures")]
        public async Task<ActionResult<List<Picture>>> GetAllPictures()
        {
            var pictures = await _pictureService.GetAllPicturesAsync();
            return Ok(pictures);
        }

        /// <summary>
        /// Delete a picture by Id.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("deletePicture/{id}")]
        public async Task<ActionResult> DeletePicture(int id)
        {
            try
            {
                await _pictureService.DeletePictureAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
