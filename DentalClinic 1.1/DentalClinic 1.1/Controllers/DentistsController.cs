using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Dentist")]
    public class DentistsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public DentistsController(UserManager<ApplicationUser> userManager,
                                  ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public string SearchTerm { get; set; }

        public async Task<IActionResult> Patients()
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
                    Email = patient.Email,
                    Id = patient.Id
                };


                listOfPatients.Add(users);
            }

            return View(listOfPatients);
        }
        public async Task<IActionResult> Appointments()
        {
            return View();
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = db.Users
                .FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            var patientDetails = new AllPatientsViewModel 
            {
                FirstName = patient.Firstname,
                LastName = patient.Lastname,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };

            return View(patientDetails);
        }

    }
}
