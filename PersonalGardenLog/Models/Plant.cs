using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalGardenLog.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the plant name.")]
        public string Name { get; set; } = string.Empty;

        public string? Species { get; set; } // Category or Species (Optional)

        [Required]
        [Range(1, 365, ErrorMessage = "Watering interval must be at least 1 day.")]
        public int WateringIntervalDays { get; set; } // Cycle (in days)

        public DateTime LastWateredDate { get; set; } = DateTime.Now; // Date of last watering

        // Automatically calculated property for next watering date
        public DateTime NextWateringDate => LastWateredDate.AddDays(WateringIntervalDays);

        // Flag to check if watering is needed
        public bool IsUrgent => DateTime.Now.Date >= NextWateringDate.Date;
    }
}