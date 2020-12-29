using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.AdministratorService
{
    public class AdministratorService : IAdministratorService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public AdministratorService(UserManager<ApplicationUser> userManager,
                                    ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public Specialization AddSpecialization(string name, string description)
        {
            var specialty = new Specialization
            {
                Name = name,
                Description = description
            };

            this.db.Specializations.Add(specialty);
            db.SaveChanges();

            return specialty;
        }

        public async Task<IList<ApplicationUser>> AllDentists()
        {
            var dentists = await userManager.GetUsersInRoleAsync("Dentist");

            return dentists;
        }

        public async Task<IList<ApplicationUser>> AllPatients()
        {
            var patients = await userManager.GetUsersInRoleAsync("Patient");

            return patients;
        }

        public async Task<IList<Specialization>> AllSpecializations()
        {
            var specialties = db.Specializations.ToList();

            return specialties;
        }

        public ApplicationUser CreateDentist(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string specialty, string description, string username)
        {
            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                Description = description,
                UserName = email
            };

            return user;
        }

        public ApplicationUser CreatePatient(string firstname, string lastname, string email, DateTime birthdate, string address, string town, string phonenumber, string username)
        {
            var user = new ApplicationUser()
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Birthdate = birthdate,
                Address = address,
                Town = town,
                PhoneNumber = phonenumber,
                UserName = email
            };

            return user;
        }

        public AllDentistsViewModel DentistDetails(string id)
        {
            if (id == null)
            {
            }

            var dentist = db.Users
                .FirstOrDefault(p => p.Id == id);
            if (dentist == null)
            {
            }

            var dentistDetails = new AllDentistsViewModel
            {
                FirstName = dentist.Firstname,
                LastName = dentist.Lastname,
                PhoneNumber = dentist.PhoneNumber,
                Email = dentist.Email,
                Address = dentist.Address,
                Description = dentist.Description
            };

            return dentistDetails;
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

        public string RemoveDentist(string id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();

            string result = "Successfuly deleted.";

            return result;
        }

        public string RemovePatient(string id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();

            string result = "Successfuly deleted.";

            return result;
        }

        public string RemoveSpecialization(int id)
        {
            var specialty = db.Specializations.Find(id);

            db.Specializations.Remove(specialty);
            db.SaveChanges();

            string result = "Successfuly deleted.";

            return result;
        }
    }
}
