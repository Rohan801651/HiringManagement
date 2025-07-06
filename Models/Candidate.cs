using System.ComponentModel.DataAnnotations;

namespace Recuriment_Platform.Models
{
    public class Candidate
    {

        [Key]
        [Required]
         public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int ? Age { get; set; }
        public int? ExperienceYear { get; set; }
        public List<Education> Educations { get; set; } = new();
        public List<Apply> Applies { get; set; } = new();



    }
}
