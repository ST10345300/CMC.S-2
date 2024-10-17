using Microsoft.AspNetCore.Mvc;

using System;
using System.ComponentModel.DataAnnotations;

namespace CMCS.Models
{
    public class Claim
    {
        [Key]
        public int ClaimID { get; set; }

        [Required]
        public int LecturerID { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [Required]
        public string ClaimStatus { get; set; } = "Pending";  // Default value

        public DateTime SubmissionDate { get; set; } = DateTime.Now;  // Default to current date

        public string? SupportingDocument { get; set; }
    }
}
