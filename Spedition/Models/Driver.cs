using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spedition.Models
{
    public class Driver
    {
        [Key]
        public int id_driver { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        public virtual Speditions Speditions { get; set; }
    }
}