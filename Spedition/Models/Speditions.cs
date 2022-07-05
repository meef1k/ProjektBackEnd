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
        public Truck Truck { get; set; }
        public int TruckId { get; set; }

        [ForeignKey("Trailer")]
        public Trailer Trailer { get; set; }
        public int TrailerId { get; set; }

        [ForeignKey("Driver")]
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
    }
}