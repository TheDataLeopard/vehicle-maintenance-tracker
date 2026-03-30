using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Service_Tracker.Models
{
    public class ServiceHistory
    {
        [Key]
        public int ServiceHistoryId { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(100)]
        public string ServiceType { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }

        [Range(0, int.MaxValue)]
        public int MileageAtService { get; set; }

        [Range(0, 1_000_000)]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [StringLength(100)]
        public string ServiceProvider { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime DateRecorded { get; set; } = DateTime.Now;

        // Navigation property
        public Vehicle? Vehicle { get; set; } = null!;
    }
}
