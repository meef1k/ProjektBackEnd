using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Spedition.Models
{
    public class User:IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
