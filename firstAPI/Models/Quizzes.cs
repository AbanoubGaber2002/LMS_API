/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public string QuizTitle { get; set; }

        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual Course Course { get; set; }
        public virtual ICollection<QuizResult> QuizResults { get; set; }

        // Constructor
        public Quiz()
        {
            QuizResults = new HashSet<QuizResult>();
        }
    }
}
*/