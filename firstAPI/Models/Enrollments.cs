/*using System;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int CourseID { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        // Navigation Properties
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
*/