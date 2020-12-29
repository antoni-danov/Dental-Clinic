using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic_1._1.Models
{
    public class Town
    {
        public Town()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}