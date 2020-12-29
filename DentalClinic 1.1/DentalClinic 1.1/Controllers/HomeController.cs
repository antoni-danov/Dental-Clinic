using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Dentist;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext db,
                              UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurClinic()
        {
            return View();
        }

        public async Task<IActionResult> OurTeam(AllDentistsViewModel input)
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
                    Id = dentist.Id,
                    Specialty = input.Specialty,
                    Description = input.Description
                };

                listOfDentists.Add(users);
            }
            return View(listOfDentists);
        }

        public async Task<IActionResult> Contact(AllDentistsViewModel input)
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

        public IActionResult Urgence()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}