using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class AddPatientViewModel : PageModel
    {
        [Required(ErrorMessage = "Enter First name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter date of birth.")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Town name.")]
        public Town Town { get; set; }

        [RegularExpression("^[0-9]{10}$")]
        [Range(5, 10)]
        [Required(ErrorMessage = "Enter Phone number.")]
        public string PhoneNumber { get; set; }
    }
}
