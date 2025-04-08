using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Api.Models;
using StudentCourseEnrollment.Api.Repositories;
using System.Threading.Tasks;

namespace StudentCourseEnrollment.Api.Controllers
{
    [Route("api/user-management")]
    [ApiController]
    [Authorize] // 🔒 Protects all endpoints with JWT authentication
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all-users")]
        [Authorize(Roles = "Admin")] // Only Admins can access
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("get-user/{id}")]
        [Authorize] // Only authenticated users can access
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpDelete("delete-user/{id}")]
        [Authorize(Roles = "Admin")] // Only Admins can delete users
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            await _userRepository.DeleteUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return Ok("User deleted successfully.");
        }
    }
}
