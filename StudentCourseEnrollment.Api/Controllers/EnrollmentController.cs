using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Api.Models;
using StudentCourseEnrollment.Api.Models.DTOs;
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
        private readonly IMapper _mapper;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        // Get all enrollments with related User and Course details
        [HttpGet("get-all-enrollments")]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAllEnrollments()
        {
            var enrollments = await _enrollmentRepository.GetAllEnrollmentsAsync();
            var enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentDto>>(enrollments);
            return Ok(enrollmentDtos);
        }

        // Get single enrollment by ID with related data
        [HttpGet("get-enrollment/{id}")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound(new { message = "Enrollment not found." });
            }
            var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
            return Ok(enrollmentDto);
        }

        // Add a new enrollment - updated to return simple success message
        [HttpPost("add-enrollment")]
        public async Task<IActionResult> AddEnrollment([FromBody] Enrollment enrollment)
        {
            if (enrollment == null)
            {
                return BadRequest(new { message = "Invalid enrollment data." });
            }

            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
            await _enrollmentRepository.SaveChangesAsync();

            // Return success message with the ID of the new enrollment
            return Ok(new
            {
                message = "Enrollment added successfully.",
                enrollmentId = enrollment.EnrollmentId
            });
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