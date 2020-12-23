using DentalClinic_1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalClinic_1._1.Services.Administrator
{
    public interface IAdministratorService
    {
        public ApplicationUser CreateUser(string firstname, string lastname, string email, DateTime birthdate, string address, Town town, string phonenumber);
    }
}
