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
        public int TruckId { get; set; }
        [ForeignKey("Trailer")]
        public int TrailerId { get; set; }
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
        public virtual ICollection<Trailer> Trailers { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}