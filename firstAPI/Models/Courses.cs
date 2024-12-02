using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)] // Restrict length for better validation
        public string CourseName { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        // Navigation Properties
        /*public virtual ICollection<Assignment> Assignments { get; set; }*/
        public virtual ICollection<Enrollment> Enrollments { get; set; }
       /* public virtual ICollection<Quiz> Quizzes { get; set; }*/

        // Constructor
        public Course()
        {
           /* Assignments = new HashSet<Assignment>();*/
            Enrollments = new HashSet<Enrollment>();
           /* Quizzes = new HashSet<Quiz>();*/
        }
    }
}
