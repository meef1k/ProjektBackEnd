using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spedition.Models
{
    public class Driver
    {
        [Key]
        public int id_driver { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string driver_name { get; set; }

        [Required]
        [Display(Name = "Driver number")]
        public string driver_number { get; set; }

        [Required]
        [Display(Name = "City")]
        public string driver_city { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}