using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services.AdministratorService;
using DentalClinic_1._1.ViewModels;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using DentalClinic_1._1.ViewModels.Specialty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;
        private readonly ILogger<ApplicationUser> logger;
        private readonly IAdministratorService administratorService;

        public AdministratorController(RoleManager<IdentityRole> roleManager,
                                       UserManager<ApplicationUser> userManager,
                                       ApplicationDbContext db,
                                       ILogger<ApplicationUser> logger,
                                      IAdministratorService administratorService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.db = db;
            this.logger = logger;
            this.administratorService = administratorService;
            this.administratorService = administratorService;
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(AddPatientViewModel input)
        {
            string password = "#A123b456";
            var roleName = "Patient";

            var user = administratorService.CreatePatient(input.FirstName, input.LastName, input.Email, input.BirthDate, input.Address, input.Town, input.PhoneNumber, input.Email);

            var patient = await userManager.CreateAsync(user, password);

            if (!patient.Succeeded)
            {
                //var token = await userManager.GenerateEmailConfirmationTokenAsync(createPatient);
                //var confirmationLink = Url.Action("ConfirmEmail", "Account",
                //    new { createPatient.Id, token = token }, Request.Scheme);
                //logger.Log(LogLevel.Warning, confirmationLink);

            }

            var result = await userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                //  TODO: handle
            }

            return Redirect("AllPatients");
        }
        //OK
        public async Task<IActionResult> RemovePatient(string id)
        {
            var user = await db.Users.FindAsync(id);

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return RedirectToAction("AllPatients");
        }
        //OK

        [HttpPost, ActionName("RemovePatient")]
        [ValidateAntiForgeryToken]
        public IActionResult RemovePatientConfirmed(string id)
        {
            var patient = administratorService.RemovePatient(id);

            return RedirectToAction("AllPatients");
        } //OK
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
                    Email = patient.Email,
                    Id = patient.Id
                };


                listOfPatients.Add(users);
            }

            return View(listOfPatients);
        }
        public IActionResult DetailsPatient(string id)
        {
            var patientDetails = administratorService.PatientDetails(id);

            return View(patientDetails);
        } //OK
        public IActionResult AddDentist(AddDentists input)
        {
            var specialties = db.Specializations.ToList();
            var user = new AddDentists
            {
                Specialty = specialties
            };

            return View(user);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDentist(AddDentistViewModel input)
        {
            var roleName = "Dentist";
            var password = "$A123b456";

            var user = administratorService.CreateDentist(input.Firstname, input.Lastname,
                                                         input.Email, input.Birthdate, input.Address,
                                                         input.Town, input.PhoneNumber, input.Specialty, input.Description,
                                                         input.Email);
            var dentist = await userManager.CreateAsync(user, password);

            if (!dentist.Succeeded)
            {
                //var token = await userManager.GenerateEmailConfirmationTokenAsync(createPatient);
                //var confirmationLink = Url.Action("ConfirmEmail", "Account",
                //    new { createPatient.Id, token = token }, Request.Scheme);
                //logger.Log(LogLevel.Warning, confirmationLink);

            }

            var result = await userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                //  TODO: handle
            }


            return Redirect("AllDentists");
        } //OK
        public async Task<IActionResult> RemoveDentist(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = await db.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            return View(dentist);
        }

        [HttpPost, ActionName("RemoveDentist")]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveDentistConfirmed(string id)
        {
            var removeDentist = administratorService.RemoveDentist(id);

            return RedirectToAction("AllDentists");
        } //OK
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
                    Email = dentist.Email,
                    Id = dentist.Id
                };

                listOfDentists.Add(users);
            }

            return View(listOfDentists);
        }
        public IActionResult DetailsDentist(string id)
        {
            var dentistDetails = administratorService.DentistDetails(id);

            return View(dentistDetails);
        } //OK

        public IActionResult AddSpecialization()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddSpecialization(AddSpecializationViewModel input)
        {
            var specialty = administratorService.AddSpecialization(input.Name, input.Description);

            return Redirect("AllSpecializations");
        } //OK
        public async Task<IActionResult> RemoveSpecialization(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await db.Specializations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        [HttpPost, ActionName("RemoveSpecialization")]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveSpecializationConfirmed(int id)
        {
            var result = administratorService.RemoveSpecialization(id);

            return RedirectToAction("AllSpecializations");
        }//OK
        public IActionResult AllSpecializations()
        {
            List<Specialization> listOfSpecializations = new List<Specialization>();
            var specializations = db.Specializations.ToList();

            foreach (var specialty in specializations)
            {

                var models = new Specialization
                {
                    Id = specialty.Id,
                    Name = specialty.Name,
                    Description = specialty.Description
                };

                listOfSpecializations.Add(models);
            }

            return View(listOfSpecializations);
        }
        
    }
}
