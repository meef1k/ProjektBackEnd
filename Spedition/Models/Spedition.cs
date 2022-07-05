using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spedition.Models
{
    public class Spedition
    {
        [Key]
        public int id_spedition { get; set; }
        [Required]
        [Display(Name = "Start place")]
        public string start_place { get; set; }
        [Required]
        [Display(Name = "Destination place")]
        public string end_place { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
