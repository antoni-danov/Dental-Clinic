using System.ComponentModel.DataAnnotations;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class AppointmentViewModel
    {
        [Key]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        public string Date { get; set; }
        public string Hour { get; set; }
        public string Minutes { get; set; }
    }
}