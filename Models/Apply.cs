using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recuriment_Platform.Models
{
    public class Apply
    {
        [Key]
        [Column(Order = 0)]
        public int JobId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CandidateId { get; set; }

        public DateTime ApplicationDate { get; set; } = DateTime.Now; // Optional attribute

        [ForeignKey("JobId")]
        public Job? Job { get; set; } // Navigation property

        [ForeignKey("CandidateId")]
        public Candidate? Candidate { get; set; } // Navigation property
    }
}