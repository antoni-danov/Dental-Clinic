using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class AddPatientViewModel
    {
        private const string RegexFirstName = @"^[A-z]*$";
        private const string RegexPhoneNumber = @"^[0-9]{10}$";

        [Key]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid first name.")]
        public string FirstName { get; set; }
        
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(RegexFirstName)]
        [Required(ErrorMessage = "Enter valid last name.")]
        public string LastName { get; set; }
       
        [Required(ErrorMessage = "Enter a valid email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
       
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter valid town name.")]
        public string Town { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
