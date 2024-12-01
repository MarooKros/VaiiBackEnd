using Microsoft.AspNetCore.Mvc;
using VaibackEnd.Models;

namespace VaibackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        /// Get all posts.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("getPosts")]
        public ActionResult<IEnumerable<Post>> GetPosts()
            => Ok(_postService.GetPosts());

        /// <summary>
        /// Get a post by Id.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getPostById")]
        public ActionResult<Post> GetPost(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        /// <summary>
        /// Create a new post.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("createPost")]
        public ActionResult<Post> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPost = _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
        }

        /// <summary>
        /// Update an existing post.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("editPost")]
        public ActionResult UpdatePost(int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = _postService.UpdatePost(id, post);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Add a comment to a post.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("addCommentToPost")]
        public ActionResult AddCommentToPost(int postId, [FromBody] Comment comment)
        {
            var success = _postService.AddCommentToPost(postId, comment);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete a post by Id.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("deletePost")]
        public ActionResult DeletePost(int id)
        {
            var success = _postService.DeletePost(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Delete a comment by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("deleteComent")]
        public ActionResult DeleteComment(int id)
        { 
            var success = _postService.DeleteCommentFromPost(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
