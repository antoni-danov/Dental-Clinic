using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.PatientsService
{
    public class PatientsService : IPatientsService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public PatientsService(UserManager<ApplicationUser> userManager,
                               ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        //public Appointment GetAppointment(DateTime appointment, string id)
        //{
        //    //var currentUser = userManager.GetUserAsync(User);
        //    //var dentist = userManager.FindByIdAsync(id);

        //    //var appointments = new Appointment
        //    //{
        //    //    Dentist = dentist.Id.ToString(),
        //    //    Patient = currentUser.Id.ToString(),
        //    //    Date = appointment.Date
        //    //};

        //    //db.Appointments.Add(appointments);
        //    //db.SaveChanges();

        //    return "";
        //}
    }
}
