using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels
{
    public class AddUserViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public Town Town { get; set; }
        [RegularExpression("^[0-9]{10}$")]
        public string PhoneNumber { get; set; }
    }
}
