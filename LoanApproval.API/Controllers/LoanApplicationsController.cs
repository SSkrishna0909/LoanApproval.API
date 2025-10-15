using Microsoft.AspNetCore.Mvc;
using LoanApproval.API.Data;
using LoanApproval.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApproval.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoanApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LoanApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanApplication>>> GetAll()
        {
            return await _context.LoanApplications.ToListAsync();
        }

        // GET: api/LoanApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanApplication>> GetById(int id)
        {
            var loan = await _context.LoanApplications.FindAsync(id);
            if (loan == null)
                return NotFound();

            return loan;
        }

        // POST: api/LoanApplications
        [HttpPost]
        public async Task<ActionResult<LoanApplication>> Create(LoanApplication loan)
        {
            _context.LoanApplications.Add(loan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = loan.Id }, loan);
        }

        // PUT: api/LoanApplications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LoanApplication loan)
        {
            if (id != loan.Id)
                return BadRequest();

            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/LoanApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.LoanApplications.FindAsync(id);
            if (loan == null)
                return NotFound();

            _context.LoanApplications.Remove(loan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
