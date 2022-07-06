using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Speditions
    {
        [Key]
        public int id_spedition { get; set; }

        [Required]
        [Display(Name = "Start place")]
        public string start_place { get; set; }

        [Required]
        [Display(Name = "Destination place")]
        public string end_place { get; set; }

        [ForeignKey("Truck")]
        [Display(Name = "Truck number")]
        public int TruckId { get; set; }

        [ForeignKey("Trailer")]
        [Display(Name = "Trailer number")]
        public int TrailerId { get; set; }

        [ForeignKey("Driver")]
        [Display(Name = "Driver name")]
        public int DriverId { get; set; }

        public virtual Truck Truck { get; set; }
        public virtual Trailer Trailer { get; set; }
        public virtual Driver Driver { get; set; }
    }
}