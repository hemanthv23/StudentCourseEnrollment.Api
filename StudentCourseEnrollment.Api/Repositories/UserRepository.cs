using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment.Api.Data;
using StudentCourseEnrollment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCourseEnrollment.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            var existingAdmin = await _context.Users.FirstOrDefaultAsync(u => u.Role == "Admin");
            if (existingAdmin == null)
            {
                user.Role = "Admin"; // First user gets Admin role
            }
            else
            {
                user.Role = "User"; // Others get User role
            }
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user); // ✅ Needed for Refresh Token updates
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}