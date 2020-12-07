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
    [Authorize(Roles = "Aministrator, Patient")]
    public class PatientsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public PatientsController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public async Task<IActionResult> Dentists()
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

        public async Task<IActionResult> AppointmentsAsync()
        {
            var userId = (await userManager.GetUserAsync(User)).Id;
            var appointments = db.Appointments.Where(a => a.Patient.Id == userId)
                .Select(a => new AppointmentViewModel
                {
                    FirstName = a.Dentist.Firstname,
                    LastName = a.Dentist.Lastname,
                    Date = a.Date
                });

            return View(appointments);
        }

        public IActionResult GetAppointment(string id)
        {
            var dentist = new CreateAppointmentViewModel { DentistId = id };
            return View(dentist);
        }

        //TODO Security too much information
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAppointmentAsync(CreateAppointmentViewModel input, string id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var dentist = await userManager.FindByIdAsync(id);

            var appointment = new Appointment
            {
                Dentist = dentist,
                Patient = currentUser,
                Date = input.Appointment
            };

            db.Appointments.Add(appointment);
            db.SaveChanges();

            return View("Appointments");
        }
        public IActionResult History()
        {
            return View();
        }

    }
}
