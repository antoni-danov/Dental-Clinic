using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class Specialization
    {
        public Specialization()
        {
            this.Users = new HashSet<ApplicationUser>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

    }
}
