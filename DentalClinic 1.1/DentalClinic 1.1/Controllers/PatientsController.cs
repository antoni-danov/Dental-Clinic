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
        } //OK

        public async Task<IActionResult> AllAppointments(Appointment input)
        {
            List<AppointmentViewModel> listOfAppointments = new List<AppointmentViewModel>();
            var userId = (await userManager.GetUserAsync(User)).Id;

            var appointments = db.Appointments.Where(a => a.Patient == userId && a.Date > DateTime.Now).ToList();

            foreach (var appointment in appointments)
            {
                var dentistUser = db.Users.First(x => x.Id == appointment.Dentist);
                
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
                Date = input.Appointment
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
