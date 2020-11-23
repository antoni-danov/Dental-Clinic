using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Models;


namespace DentalClinic_1._1.ViewModels.Dentist
{
    public class GetAllDentistsViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialty { get; set; }
    }
}
