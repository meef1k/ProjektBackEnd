using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Truck
    {
        [Key]
        public int id_truck { get; set; }
        [Required]
        public string truck_number { get; set; }
        [Required]
        public string truck_manufacturer { get; set; }
        [Required]
        public string truck_model { get; set; }
        [Required]
        public string truck_plate { get; set; }
        public virtual Package Package { get; set; }
    }
}
