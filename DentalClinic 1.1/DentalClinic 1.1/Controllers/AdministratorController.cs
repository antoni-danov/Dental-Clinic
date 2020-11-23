using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using DentalClinic_1._1.ViewModels.Specialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public AdministratorController(RoleManager<IdentityRole> roleManager,
                                       UserManager<ApplicationUser> userManager,
                                       ApplicationDbContext db)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(AddPatientViewModel input)
        {
            var roleName = "Patient";

            var createPatient = new ApplicationUser
            {
                Firstname = input.FirstName,
                Lastname = input.LastName,
                Email = input.Email,
                Birthdate = input.BirthDate,
                Address = input.Address,
                Town = input.Town,
                PhoneNumber = input.PhoneNumber

            };

            var user = await userManager.CreateAsync(createPatient);
            var userManage = await userManager.GetUserAsync(User);

            if (!User.IsInRole(roleName))
            {
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }

            return Redirect("/AllPatients");
        }
        public IActionResult RemovePatient()
        {

            return View();
        }
        public async Task<IActionResult> AllPatients()
        {
            List<AllPatientsViewModel> listOfPatients = new List<AllPatientsViewModel>();
            var patients = await userManager.GetUsersInRoleAsync("Patient");

            foreach (var patient in patients)
            {

                var users = new AllPatientsViewModel
                {
                    FirstName = patient.Firstname,
                    LastName = patient.Lastname,
                    PhoneNumber = patient.PhoneNumber,
                    Email = patient.Email
                };

                listOfPatients.Add(users);
            }

            return View(listOfPatients);
        }
        public IActionResult AddDentist()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDentist(AddDentistViewModel input)
        {
            var roleName = "Dentist";
            var userManage = await userManager.GetUserAsync(User);

            if (!User.IsInRole(roleName))
            {
                var result = await userManager.AddToRoleAsync(userManage, roleName);
            }
            return View();
        }
        public IActionResult RemoveDentist()
        {
            return View();
        }
        public async Task<IActionResult> AllDentists()
        {
            List<AllDentistsViewModel> listOfDentists = new List<AllDentistsViewModel>();
            var dentists = await userManager.GetUsersInRoleAsync("Dentist");

            foreach (var dentist in dentists)
            {

                var users = new AllDentistsViewModel
                {
                    FirstName = dentist.Firstname,
                    LastName = dentist.Lastname,
                    PhoneNumber = dentist.PhoneNumber,
                    Email = dentist.Email
                };

                listOfDentists.Add(users);
            }

            return View(listOfDentists);
        }
        public IActionResult AddSpecialization()
        {
            return View();
        }
        public IActionResult RemoveSpecialization()
        {
            return View();
        }
        public IActionResult AllSpecialties()
        {
            //List<AllSpecializationViewModel> listOfSpecializations = new List<AllSpecializationViewModel>();

            //foreach (var specialty in )
            //{

            //    var models = new AllSpecializationViewModel
            //    {
            //        SpecialtyName = specialty,
            //        DentistFirstName = specialty.Firstname,
            //        DentistLastName = specialty.Lastname
            //    };

            //    listOfSpecializations.Add(models);
            //}

            return View( );
        }
    }
}
