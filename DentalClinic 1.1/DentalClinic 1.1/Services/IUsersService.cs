using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public interface IUsersService
    {
        public string CreatePatient(AddPatientViewModel input);
        public IEnumerable<AddPatientViewModel> AllPatients();
        public string CreateDentist(AddDentistViewModel input);
        public IEnumerable<AddDentistViewModel> AllDentists();

    }
}
