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
    public class DeleteAccountsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeleteAccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DeleteAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeleteAccount>>> GetDeleteAccounts()
        {
            return await _context.DeleteAccounts.Include(da => da.Admin) // Якщо потрібно включити Admin
                                               .ToListAsync();
        }

        // GET: api/DeleteAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeleteAccount>> GetDeleteAccount(int id)
        {
            var deleteAccount = await _context.DeleteAccounts.Include(da => da.Admin) // Якщо потрібно включити Admin
                                                             .FirstOrDefaultAsync(da => da.Id == id);

            if (deleteAccount == null)
            {
                return NotFound();
            }

            return deleteAccount;
        }

        // PUT: api/DeleteAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeleteAccount(int id, DeleteAccount deleteAccount)
        {
            if (id != deleteAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(deleteAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeleteAccountExists(id))
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

        // POST: api/DeleteAccounts
        [HttpPost]
        public async Task<ActionResult<DeleteAccount>> PostDeleteAccount(DeleteAccount deleteAccount)
        {
            _context.DeleteAccounts.Add(deleteAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeleteAccount", new { id = deleteAccount.Id }, deleteAccount);
        }

        // DELETE: api/DeleteAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeleteAccount(int id)
        {
            var deleteAccount = await _context.DeleteAccounts.FindAsync(id);
            if (deleteAccount == null)
            {
                return NotFound();
            }

            _context.DeleteAccounts.Remove(deleteAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeleteAccountExists(int id)
        {
            return _context.DeleteAccounts.Any(e => e.Id == id);
        }
    }
}
