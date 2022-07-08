using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Trailer
    {
        [Key]
        public int id_trailer { get; set; }

        [Required]
        [Display(Name = "Trailer Number")]
        public string trailer_number { get; set; }

        [Required]
        [Display(Name = "Trailer Manufacturer")]
        public string trailer_manufacturer { get; set; }

        [Required]
        [Display(Name = "Trailer Model")]
        public string trailer_model { get; set; }

        [Required]
        [Display(Name = "Trailer Number plate")]
        public string trailer_plate { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }
    }
}