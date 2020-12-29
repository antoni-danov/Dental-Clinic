using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services.DentistsController;
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
        private readonly IDentistsService dentistsService;

        public DentistsController(UserManager<ApplicationUser> userManager,
                                  ApplicationDbContext db,
                                  IDentistsService dentistsService)
        {
            this.userManager = userManager;
            this.db = db;
            this.dentistsService = dentistsService;
        }

        public async Task<IActionResult> Patients(string searchString)
        {
            List<AllPatientsViewModel> listOfPatients = new List<AllPatientsViewModel>();
            var patients = await userManager.GetUsersInRoleAsync("Patient");

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = (List<ApplicationUser>)patients.Where(x => x.Firstname.Contains(searchString) || x.Lastname.Contains(searchString));
            }

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
            return View(listOfPatients.ToList());

        }
        public async Task<IActionResult> Appointments()
        {
            return View();
        }
        public IActionResult Details(string id)
        {
            var patientDetails = dentistsService.PatientDetails(id);

            return View(patientDetails);
        } //OK

    }
}
