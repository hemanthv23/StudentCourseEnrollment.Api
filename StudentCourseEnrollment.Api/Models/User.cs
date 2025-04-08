namespace StudentCourseEnrollment.Api.Models
{
    public class User
    {
        public int UserId { get; set; } // Primary key
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; } 
    }
}


//{
//    "email": "admin@gmail.com",
//  "password": "admin@123"
//}