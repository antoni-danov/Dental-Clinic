using System.ComponentModel.DataAnnotations;

namespace DentalClinic_1._1.ViewModels.Specialty
{
    public class AddSpecializationViewModel
    {
        [Key]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
    }
}