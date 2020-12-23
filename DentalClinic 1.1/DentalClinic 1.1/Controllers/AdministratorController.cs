using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services.Administrator;
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
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient(AddPatientViewModel input)
        {
            var password = "#A123b456";

            var roleName = "Patient";

            var patient = administratorService.CreateUser(input.FirstName, input.LastName, input.Email, input.BirthDate, input.Address, input.Town, input.PhoneNumber);

            var user = await userManager.CreateAsync(patient, password);

            if (!user.Succeeded)
            {
                //var token = await userManager.GenerateEmailConfirmationTokenAsync(createPatient);
                //var confirmationLink = Url.Action("ConfirmEmail", "Account",
                //    new { createPatient.Id, token = token }, Request.Scheme);
                //logger.Log(LogLevel.Warning, confirmationLink);

            }

            var result = await userManager.AddToRoleAsync(patient, roleName);

            if (!result.Succeeded)
            {
                //  TODO: handle
            }

            return Redirect("AllPatients");
        }
        public async Task<IActionResult> RemovePatient(string id)
        {
            var patient = administratorService.GetPatientById(id);

            return View(patient);
        }

        [HttpPost, ActionName("RemovePatient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePatientConfirmed(string id)
        {
            var user = await db.Users.FindAsync(id);

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            
            return RedirectToAction("AllPatients");
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
                    Email = patient.Email,
                    Id = patient.Id
                };


                listOfPatients.Add(users);
            }

            return View(listOfPatients);
        }
        public IActionResult DetailsPatient(string id)
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
                Email = patient.Email,
                Address = patient.Address
            };

            return View(patientDetails);
        } //TODO
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
        public async Task<IActionResult> AddDentist(AddDentists input, Specialization specialty)
        {
            var roleName = "Dentist";
            var password = "$A123b456";

            var createDentist = new ApplicationUser
            {
                Firstname = input.Dentist.Firstname,
                Lastname = input.Dentist.Lastname,
                Email = input.Dentist.Email,
                Birthdate = input.Dentist.Birthdate,
                Address = input.Dentist.Address,
                Town = input.Dentist.Town,
                PhoneNumber = input.Dentist.PhoneNumber,
                Description = input.Dentist.Description,
                Specialty = (Specialization)input.Specialty,
                UserName = input.Dentist.Email
            };

            var user = await userManager.CreateAsync(createDentist, password);

            if (!user.Succeeded)
            {
                //var token = await userManager.GenerateEmailConfirmationTokenAsync(createDentist);
                //var confirmationLink = Url.Action("ConfirmEmail", "Account", 
                //    new { createDentist.Id, token = token}, Request.Scheme );
                //logger.Log(LogLevel.Warning, confirmationLink);

            }

            var result = await userManager.AddToRoleAsync(createDentist, roleName);

            if (!user.Succeeded)
            {
                //TODO
            }

            return Redirect("AllDentists");
        }
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
        public async Task<IActionResult> RemoveDentistConfirmed(string id)
        {
            var user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("AllDentists");
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
                    Email = dentist.Email,
                    Id = dentist.Id
                };

                listOfDentists.Add(users);
            }

            return View(listOfDentists);
        }
        public IActionResult DetailsDentist(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dentist = db.Users
                .FirstOrDefault(p => p.Id == id);
            if (dentist == null)
            {
                return NotFound();
            }

            var dentistDetails = new AllDentistsViewModel
            {
                FirstName = dentist.Firstname,
                LastName = dentist.Lastname,
                PhoneNumber = dentist.PhoneNumber,
                Email = dentist.Email,
                Address = dentist.Address,
                Autobiography = dentist.Description
            };

            return View(dentistDetails);
        } //TODO

        public IActionResult AddSpecialization()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddSpecialization(AddSpecializationViewModel input)
        {
            var specialty = new Specialization
            {
                Name = input.Name,
                Description = input.Description
            };

            this.db.Specializations.Add(specialty);
            db.SaveChanges();

            return Redirect("AllSpecializations");
        }
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
        public async Task<IActionResult> RemoveSpecializationConfirmed(int id)
        {
            var specialty = await db.Specializations.FindAsync(id);
            db.Specializations.Remove(specialty);
            await db.SaveChangesAsync();
            return RedirectToAction("AllSpecializations");
        }
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
        [HttpPost]
        public IActionResult EditDetails(int id)
        {
            var specialty = db.Specializations.First(x => x.Id == id);

            return View();
        }
    }
}
