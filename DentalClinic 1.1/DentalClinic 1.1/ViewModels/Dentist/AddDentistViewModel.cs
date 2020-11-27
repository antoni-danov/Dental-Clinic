using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Dentist
{
    public class AddDentistViewModel
    {
        private const string RegexFirstName = @"^[A-z]*$";
        private const string RegexPhoneNumber = @"^[0-9]{10}$";

        [Key]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid first name.")]
        public string Firstname { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid last name.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter valide email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter valid town name.")]
        public Town Town { get; set; }

        [Required]
        [RegularExpression(RegexPhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
      
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public Specialization SpecialtyName { get; set; }

    }
}
