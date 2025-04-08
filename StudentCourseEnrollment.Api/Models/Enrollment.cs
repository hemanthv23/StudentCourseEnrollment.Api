namespace StudentCourseEnrollment.Api.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        // Foreign Key: User (Student)
        public int UserId { get; set; }
        public User? User { get; set; } // Allow null in case it's not loaded

        // Foreign Key: Course
        public int CourseId { get; set; }
        public Course? Course { get; set; } // Allow null in case it's not loaded

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}