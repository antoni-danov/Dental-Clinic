using DentalClinic_1._1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public interface IUsersService
    {
        public string CreateUser(AddPatientViewModel input);
        public IEnumerable<AddPatientViewModel> All();

    }
}
