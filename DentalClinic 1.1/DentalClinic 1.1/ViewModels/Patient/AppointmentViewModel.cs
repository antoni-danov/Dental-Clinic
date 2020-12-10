using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class AppointmentViewModel
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Minutes { get; set; }
    }
}
