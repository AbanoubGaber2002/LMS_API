/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual Course Course { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }

        // Constructor
        public Assignment()
        {
            Submissions = new HashSet<Submission>();
        }
    }
}
*/