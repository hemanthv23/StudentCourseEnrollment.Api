using StudentCourseEnrollment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCourseEnrollment.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user); 
        Task SaveChangesAsync();
    }
}
