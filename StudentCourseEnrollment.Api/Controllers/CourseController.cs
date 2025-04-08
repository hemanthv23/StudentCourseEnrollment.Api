using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Api.Models;
using StudentCourseEnrollment.Api.Repositories;

namespace StudentCourseEnrollment.Api.Controllers
{
    [Route("api/course-management")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet("all-courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("get-course/{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }
            return Ok(course);
        }

        [HttpPost("add-course")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _courseRepository.AddCourseAsync(course);
            await _courseRepository.SaveChangesAsync();
            return Ok("Course added successfully.");
        }

        [HttpPut("update-course/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course updatedCourse)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            course.Title = updatedCourse.Title;
            course.Description = updatedCourse.Description;
            course.CoverImagePath = updatedCourse.CoverImagePath; // Fixed Property Name

            await _courseRepository.SaveChangesAsync();
            return Ok("Course updated successfully.");
        }

        [HttpDelete("delete-course/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            await _courseRepository.DeleteCourseAsync(course);
            await _courseRepository.SaveChangesAsync();

            return Ok("Course deleted successfully.");
        }
    }
}
