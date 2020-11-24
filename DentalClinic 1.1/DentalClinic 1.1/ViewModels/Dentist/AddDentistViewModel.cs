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
        [Key]
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public Town Town { get; set; }

        //[RegularExpression("^[0-9]{10}$")]
        //[Range(5, 10)]
        [Required]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

    }
}
