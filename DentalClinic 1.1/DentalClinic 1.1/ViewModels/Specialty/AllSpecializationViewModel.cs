using System.ComponentModel.DataAnnotations;

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