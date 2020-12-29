using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Models;


namespace DentalClinic_1._1.ViewModels.Dentist
{
    public class AllDentistsViewModel
    {
        private const string RegexFirstName = @"^[A-z]*$";

        [Key]
        public string Id { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid first name.")]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid last name.")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter valide email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

    }
}
