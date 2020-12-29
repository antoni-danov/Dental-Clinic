using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DentalClinic_1._1.Models
{
    public class ApplicationUser : IdentityUser
    {
        private const string RegexFirstName = @"^[A-z]*$";

        public ApplicationUser()
        {
            Appointments = new HashSet<Appointment>();
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }
        public string Address { get; set; }

        public string Town { get; set; }
        public string Specialty { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string Description { get; set; }
    }
}