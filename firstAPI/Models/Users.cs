using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // Navigation Properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
       /* public virtual ICollection<QuizResult> QuizResults { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }*/

        // Constructor
        public User()
        {
            Enrollments = new HashSet<Enrollment>();
           /* QuizResults = new HashSet<QuizResult>();
            Submissions = new HashSet<Submission>();*/
        }
    }
}
