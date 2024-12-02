using firstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrollment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
        {
            var enrollments = await _context.Enrollments.Include(e => e.Course).Include(e => e.User).ToListAsync();
            return Ok(enrollments);
        }

        // GET: api/Enrollment/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.Include(e => e.Course).Include(e => e.User)
                .FirstOrDefaultAsync(e => e.EnrollmentID == id);

            if (enrollment == null)
            {
                return NotFound(new { Message = $"Enrollment with ID {id} not found." });
            }

            return Ok(enrollment);
        }

        // POST: api/Enrollment
        [HttpPost]
        public async Task<ActionResult<Enrollment>> CreateEnrollment([FromBody] Enrollment enrollment)
        {
              
            if (!ModelState.IsValid)
            {
               
                return BadRequest(ModelState);
            }

            enrollment.EnrollmentDate = enrollment.EnrollmentDate ?? DateTime.UtcNow;

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentID }, enrollment);
        }


        

        // PUT: api/Enrollment/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentID)
            {
                return BadRequest(new { Message = "Enrollment ID in the URL does not match the Enrollment ID in the body." });
            }

            var existingEnrollment = await _context.Enrollments.FindAsync(id);
            if (existingEnrollment == null)
            {
                return NotFound(new { Message = $"Enrollment with ID {id} not found." });
            }

            // Update fields
            existingEnrollment.UserID = enrollment.UserID;
            existingEnrollment.CourseID = enrollment.CourseID;
            existingEnrollment.EnrollmentDate = enrollment.EnrollmentDate ?? existingEnrollment.EnrollmentDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the enrollment." });
            }

            return NoContent();
        }

        // DELETE: api/Enrollment/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound(new { Message = $"Enrollment with ID {id} not found." });
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
