using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class AllPatientsViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

    }
}
