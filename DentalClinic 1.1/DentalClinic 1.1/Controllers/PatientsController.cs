using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.Services.PatientsService;
using DentalClinic_1._1.ViewModels.Dentist;
using DentalClinic_1._1.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;
        private readonly IPatientsService patientsService;

        public PatientsController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext db,
            IPatientsService patientsService)
        {
            this.userManager = userManager;
            this.db = db;
            this.patientsService = patientsService;
        }

        public async Task<IActionResult> Dentists()
        {
            var dentists = (await patientsService.AllDentists()).Select(dentist => new AllDentistsViewModel
            {
                FirstName = dentist.Firstname,
                LastName = dentist.Lastname,
                PhoneNumber = dentist.PhoneNumber,
                Email = dentist.Email,
                Id = dentist.Id
            });

            return View(dentists);
        } //OK

        public async Task<IActionResult> AllAppointments()
        {
            List<AppointmentViewModel> listOfAppointments = new List<AppointmentViewModel>();
            var userId = (await userManager.GetUserAsync(User)).Id;

            var appointments = db.Appointments.Where(a => a.Patient == userId && a.Date > DateTime.Now).ToList();

            if (ModelState.IsValid)
            {
                foreach (var appointment in appointments)
                {
                    var dentistUser = db.Users.FirstOrDefault(x => x.Id == appointment.Dentist.ToString());

                    var user = new AppointmentViewModel
                    {
                        FirstName = dentistUser.Firstname,
                        LastName = dentistUser.Lastname,
                        Date = appointment.Date.ToString("dd MMMM yyyy"),
                        Hour = appointment.Date.ToString("HH"),
                        Minutes = appointment.Date.ToString("mm")
                    };
                    listOfAppointments.Add(user);
                }
            }

            return View("AllAppointments", listOfAppointments);
        } //OK

        public IActionResult GetAppointment() //OK
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAppointment(DateTimeViewModel input, string id)
        {
            var currentUser = await userManager.GetUserAsync(User);
            var dentist = await userManager.FindByIdAsync(id);

            var appointment = new Appointment
            {
                Dentist = dentist.Id,
                Patient = currentUser.Id,
                Date = input.Appointment,
                UserId = currentUser.Id
            };

            db.Appointments.Add(appointment);
            db.SaveChanges();

            return RedirectToAction("AllAppointments", appointment);
        } //OK

        public IActionResult History()
        {
            return View();
        }
    }
}