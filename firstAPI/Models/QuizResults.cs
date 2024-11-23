/*using System;
using System.ComponentModel.DataAnnotations;

namespace firstAPI.Models
{
    public class QuizResult
    {
        [Key]
        public int QuizResultID { get; set; }

        [Required]
        public int QuizID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [Range(0, 100)] // Assuming score is between 0 and 100
        public decimal Score { get; set; }

        public DateTime? TakenAt { get; set; }

        // Navigation Properties
        public virtual Quiz Quiz { get; set; }
        public virtual User User { get; set; }
    }
}
*/