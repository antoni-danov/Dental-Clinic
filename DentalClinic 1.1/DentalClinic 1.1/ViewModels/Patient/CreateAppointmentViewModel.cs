using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.ViewModels.Patient
{
    public class CreateAppointmentViewModel
    {
        [Key]
        public string DentistId { get; set; }
        public string PatientId { get; set; }
        public DateTime Appointment { get; set; }
    }
}
