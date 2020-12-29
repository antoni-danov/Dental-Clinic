using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.DentistsController
{
    public class DentistsService : IDentistsService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public DentistsService(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public List<Appointment> AllAppointments(string id)
        {
            var appointments = db.Appointments.Where(x => x.Dentist == id).ToList();
            
            return appointments;
        }

        public async Task<IList<ApplicationUser>> AllPatients()
        {
            var patients = await userManager.GetUsersInRoleAsync("Patient");

            return patients;
        }

        public async Task<IList<ApplicationUser>> AllPatients(string searchString)
        {
            var patients = await userManager.GetUsersInRoleAsync("Patient");

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = (List<ApplicationUser>)patients.Where(x => x.Firstname.Contains(searchString) || x.Lastname.Contains(searchString));
            }

            return patients;
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