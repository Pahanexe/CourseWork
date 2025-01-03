using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestApi.Data;
using MyRestApi.models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentModerationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentModerationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentModerations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModeration>>> GetCommentModerations()
        {
            return await _context.CommentModerations.Include(cm => cm.User)       // Якщо потрібно включити User
                                                   .Include(cm => cm.Moderator)  // Якщо потрібно включити Moderator
                                                   .ToListAsync();
        }

        // GET: api/CommentModerations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModeration>> GetCommentModeration(int id)
        {
            var commentModeration = await _context.CommentModerations.Include(cm => cm.User)       // Якщо потрібно включити User
                                                                     .Include(cm => cm.Moderator)  // Якщо потрібно включити Moderator
                                                                     .FirstOrDefaultAsync(cm => cm.CommentId == id);

            if (commentModeration == null)
            {
                return NotFound();
            }

            return commentModeration;
        }

        // PUT: api/CommentModerations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentModeration(int id, CommentModeration commentModeration)
        {
            if (id != commentModeration.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(commentModeration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentModerationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CommentModerations
        [HttpPost]
        public async Task<ActionResult<CommentModeration>> PostCommentModeration(CommentModeration commentModeration)
        {
            _context.CommentModerations.Add(commentModeration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentModeration", new { id = commentModeration.CommentId }, commentModeration);
        }

        // DELETE: api/CommentModerations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentModeration(int id)
        {
            var commentModeration = await _context.CommentModerations.FindAsync(id);
            if (commentModeration == null)
            {
                return NotFound();
            }

            _context.CommentModerations.Remove(commentModeration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentModerationExists(int id)
        {
            return _context.CommentModerations.Any(e => e.CommentId == id);
        }
    }
}
