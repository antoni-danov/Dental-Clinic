using DentalClinic_1._1.ViewModels.Specialty;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Models
{
    public class ApplicationUser : IdentityUser
    {
        private const string RegexFirstName = @"^[A-z]*$";

        public ApplicationUser()
        {
            Appointments = new HashSet<Appointment>();
        }
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid first name.")]
        public string Firstname { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid last name.")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter valid town name.")]
        public string Town { get; set; }
        public string Specialty { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public string Description { get; set; }

    }
}
