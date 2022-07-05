using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Package
    {
        [Key]
        public int id_package { get; set; }
        [ForeignKey("Truck")]
        [Display(Name = "Truck")]
        public int id_truck { get; set; }
        [ForeignKey("Trailer")]
        [Display(Name = "Trailer")]
        public int id_trailer { get; set; }
        public virtual Truck Truck { get; set; }
        public virtual Trailer Trailer { get; set; }
        public virtual ICollection<Spedition> Spedition { get; set; }
    }
}
