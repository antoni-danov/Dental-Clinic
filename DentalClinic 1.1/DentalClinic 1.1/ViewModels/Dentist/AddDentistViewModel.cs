﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DentalClinic_1._1.ViewModels.Dentist
{
    public class AddDentistViewModel
    {
        private const string RegexFirstName = @"^[A-z]*$";

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

        [Required(ErrorMessage = "Enter valid address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter valid town name.")]
        public string Town { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Specialty { get; set; }
    }
}