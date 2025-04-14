namespace StudentCourseEnrollment.Api.Models.DTOs
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; } // Uses UserDto instead of User to avoid exposing tokens
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}