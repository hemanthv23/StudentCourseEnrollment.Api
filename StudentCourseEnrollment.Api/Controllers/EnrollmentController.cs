using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Api.Models;
using StudentCourseEnrollment.Api.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCourseEnrollment.Api.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // Get all enrollments with related User and Course details
        [HttpGet("get-all-enrollments")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllEnrollments()
        {
            var enrollments = await _enrollmentRepository.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        // Get single enrollment by ID with related data
        [HttpGet("get-enrollment/{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound(new { message = "Enrollment not found." });
            }
            return Ok(enrollment);
        }

        // Add a new enrollment
        [HttpPost("add-enrollment")]
        public async Task<IActionResult> AddEnrollment([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest(new { message = "Invalid enrollment data." });
            }

            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.EnrollmentId }, enrollment);
        }

        // Delete an enrollment
        [HttpDelete("delete-enrollment/{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound(new { message = "Enrollment not found." });
            }

            await _enrollmentRepository.DeleteEnrollmentAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            return Ok(new { message = "Enrollment deleted successfully." });
        }
    }
}
