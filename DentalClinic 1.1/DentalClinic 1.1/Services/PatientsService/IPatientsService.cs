using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.PatientsService
{
    public interface IPatientsService
    {
        //public Appointment GetAppointment(DateTime appointment, string id);
        public Task<IList<ApplicationUser>> AllDentists();

    }
}
