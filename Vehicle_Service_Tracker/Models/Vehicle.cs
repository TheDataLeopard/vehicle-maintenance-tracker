using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vehicle_Service_Tracker.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = string.Empty;

        //[Range(1886, 2100)]
        public int Year { get; set; }

        [StringLength(50)]
        public string? VIN { get; set; }

        [StringLength(20)]
        public string? LicensePlate { get; set; }

        [Range(0, int.MaxValue)]
        public int CurrentMileage { get; set; }

        public string? ImagePath { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<ServiceHistory> ServiceHistories { get; set; }
            = new List<ServiceHistory>();
    }
}
