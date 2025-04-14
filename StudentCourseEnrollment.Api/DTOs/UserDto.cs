namespace StudentCourseEnrollment.Api.Models.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        // RefreshToken and RefreshTokenExpiryTime are deliberately omitted
    }
}