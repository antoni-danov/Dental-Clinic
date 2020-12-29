using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Specialty
{
    public class AllSpecializationViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string SpecialtyName { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}
