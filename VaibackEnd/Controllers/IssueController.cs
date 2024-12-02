using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaibackEnd.Data;
using VaibackEnd.Models;

namespace VaibackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;
        /// <summary>
        /// Returns list of Issues.
        /// </summary>
        [HttpGet("getIssues")]
        public async Task<IEnumerable<Issue>> GetIssues()
            => await _context.Issues.ToListAsync();

        /// <summary>
        /// Returns issue by Id.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getIssueById")]
        public async Task<IActionResult> GetIssueById(int id)
        {
            var issue = _context.Issues.FindAsync(id);
            return await issue == null ? NotFound() : Ok(issue);
        }

        /// <summary>   
        /// Creates a new Issue.
        /// </summary>
        /// <param name="issue"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("createIssue")]
        public async Task<IActionResult> CreateIssue(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIssueById), new { id = issue.Id }, issue);
        }

        /// <summary>
        /// Updates Issue.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="issue"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("editIssue")]
        public async Task<IActionResult> UpdateIssue(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }
             _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Deletes an Issue.
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("deleteIssue")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            if (issueToDelete == null)
            {
                return NotFound();
            }
            
            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
