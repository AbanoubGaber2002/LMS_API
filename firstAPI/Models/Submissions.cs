/*using System;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionID { get; set; }

        [Required]
        public int AssignmentID { get; set; }

        [Required]
        public int UserID { get; set; }

        public DateTime? SubmissionDate { get; set; }
        public string Content { get; set; }
        public decimal? Grade { get; set; }

        // Navigation Properties
        public virtual Assignment Assignment { get; set; }
        public virtual User User { get; set; }
    }
}
*/