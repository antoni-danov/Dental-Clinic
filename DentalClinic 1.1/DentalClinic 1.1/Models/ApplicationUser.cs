using DentalClinic_1._1.ViewModels.Specialty;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Appointments = new HashSet<Appointment>();
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public Town Town { get; set; }
        public string Specialty { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string Description { get; set; }

    }
}
