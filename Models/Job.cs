// Models/Job.cs
using System.ComponentModel.DataAnnotations;

namespace Recuriment_Platform.Models
{
    public class Job
    {
        [Key]
        public int? jobId { get; set; }
        public string? jobTitle { get; set; }
        public string? companyName { get; set; }
        public string? jobDescription { get; set; }
        public string? jobLocation { get; set; }
        public double? jobSalary { get; set; }
        public string? jobType { get; set; }
        public int? numberEmployees { get; set; }
        public DateTime? deadline { get; set; }
        public string? jobRequirment { get; set; }
        public List<Apply> Applies { get; set; } = new();
    }
}
