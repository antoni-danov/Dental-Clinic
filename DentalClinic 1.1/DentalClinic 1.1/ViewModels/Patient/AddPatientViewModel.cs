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

        [Key]
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Email.")]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        [Required]
        public Town Town { get; set; }

        [RegularExpression("^[0-9]{10}$")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
