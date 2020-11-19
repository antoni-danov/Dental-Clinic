using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
