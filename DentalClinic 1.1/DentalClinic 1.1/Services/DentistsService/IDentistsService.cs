using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.DentistsController
{
    public interface IDentistsService
    {
        public AllPatientsViewModel PatientDetails(string id);
        public Task<IList<ApplicationUser>> AllPatients();
        public Task<IList<ApplicationUser>> AllPatients(string searchString);

    }
}
