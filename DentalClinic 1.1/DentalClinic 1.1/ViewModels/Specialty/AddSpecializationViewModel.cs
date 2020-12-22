using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Specialty
{
    public class AddSpecializationViewModel
    {
        private const string RegexSpecialty = @"^[A-z]* [A-z]*$";

        [Key]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(RegexSpecialty)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        
    }
}
