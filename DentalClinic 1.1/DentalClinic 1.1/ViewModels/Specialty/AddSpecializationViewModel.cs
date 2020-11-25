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
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        
    }
}
