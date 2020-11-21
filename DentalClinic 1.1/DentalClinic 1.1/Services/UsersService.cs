using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using DentalClinic_1._1.ViewModels.Specialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        //public string CreatePatient(AddPatientViewModel input)
        //{
        //    var user = new ApplicationUser
        //    {
        //        Firstname = input.Firstname,
        //        Lastname = input.Lastname,
        //        Email = input.Email,
        //        Birthdate = input.Birthdate,
        //        Town = input.Town,
        //        PhoneNumber = input.PhoneNumber
        //    };

        //    var result = this.userManager.CreateAsync(user);

        //    return user.Id.ToString();
        //}

        public IEnumerable<AddPatientViewModel> AllPatients()
        {
            var patients = this.db.Users.Select
                (p => new AddPatientViewModel
                {
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Email = p.Email,
                    Birthdate = p.Birthdate,
                    Town = p.Town,
                    PhoneNumber = p.PhoneNumber
                }).ToList();

            return patients;
        }

        public IEnumerable<AddDentistViewModel> AllDentists()
        {
            var dentists = this.db.Users.Select
                (p => new AddDentistViewModel
                {
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Email = p.Email,
                    Birthdate = p.Birthdate,
                    Town = p.Town,
                    PhoneNumber = p.PhoneNumber
                }).ToList();

            return dentists;
        }

        public string CreateDentist(AddDentistViewModel input)
        {
            var dentist = new ApplicationUser
            {
                Firstname = input.Firstname,
                Lastname = input.Lastname,
                Email = input.Email,
                Birthdate = input.Birthdate,
                Address = input.Address,
                Town = input.Town,
                PhoneNumber = input.PhoneNumber,
                Description = input.Description
            };

            this.db.Users.Add(dentist);
            this.db.SaveChanges();

            return dentist.Id;
        }

        //TODO
        public string CreateSpecialization(AddSpecializationViewModel input)
        {
            throw new NotImplementedException();
        }

       
    }
}
