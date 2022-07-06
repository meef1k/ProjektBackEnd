using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Truck
    {
        [Key]
        public int id_truck { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string truck_number { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public string truck_manufacturer { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string truck_model { get; set; }

        [Required]
        [Display(Name = "Number plate")]
        public string truck_plate { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
