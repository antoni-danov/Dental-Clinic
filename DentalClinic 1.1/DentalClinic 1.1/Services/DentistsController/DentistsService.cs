using DentalClinic_1._1.Data;
using DentalClinic_1._1.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.DentistsController
{
    public class DentistsService : IDentistsService
    {
        private readonly ApplicationDbContext db;

        public DentistsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public AllPatientsViewModel PatientDetails(string id)
        {
            if (id == null)
            {
            }

            var patient = db.Users
                .FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
            }

            var patientDetails = new AllPatientsViewModel
            {
                FirstName = patient.Firstname,
                LastName = patient.Lastname,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                Address = patient.Address
            };

            return patientDetails;
        }
    }
}
