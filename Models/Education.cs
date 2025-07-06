using System.ComponentModel.DataAnnotations;

namespace Recuriment_Platform.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Degree { get; set; } // Add 'required'

        [Required]
        public required string Institution { get; set; } // Add 'required'

        [Required]
        [Range(1.5, 4.0, ErrorMessage = "CGPA must be between 0.0 and 4.0")]
        public double CGPA { get; set; }

        [Required]
        public DateOnly Year { get; set; }

        [Required]
        public int CandidateId { get; set; }

        public Candidate? Candidate { get; set; }
    }
}