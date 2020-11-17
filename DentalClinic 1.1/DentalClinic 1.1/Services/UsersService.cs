using DentalClinic_1._1.Data;
using DentalClinic_1._1.Models;
using DentalClinic_1._1.ViewModels.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(AddUserViewModel input)
        {
            var user = new ApplicationUser
            {
                Firstname = input.Firstname,
                Lastname = input.Lastname,
                Email = input.Email,
                Birthdate = input.Birthdate,
                Town = input.Town,
                PhoneNumber = input.PhoneNumber
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public IEnumerable<AddUserViewModel> All()
        {
            var patients = this.db.Users.Select
                (p => new AddUserViewModel
                {
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Email = p.Email,
                    Birthdate = p.Birthdate,
                    Town = p.Town,
                    PhoneNumber = p.PhoneNumber
                }).ToList();
           
            return patients;
        }
    }
}
