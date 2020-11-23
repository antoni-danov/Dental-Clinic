using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Patient
{
    public class PatientsService : IPatientsService
    {
        public  async Task<AddPatientViewModel> CreatePatient(AddPatientViewModel input)
        {
            var patient = new AddPatientViewModel 
            {

            };

            return patient;
        }
    }
}
