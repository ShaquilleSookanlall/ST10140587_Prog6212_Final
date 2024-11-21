using System.ComponentModel.DataAnnotations;

namespace ST10140587_Prog6212_Part2.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double HoursWorked { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double HourlyRate { get; set; }

        public string Notes { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [Required]
        public string? DocumentPath { get; set; }
    }
}