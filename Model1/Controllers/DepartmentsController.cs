using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model1.Models;

namespace Model1.Controllers
{
    public class DepartmentsController : Controller

    {
        public IActionResult Index()
        {
            var repo = new DepartmentsRepository();
            var products = repo.GetAllDepartments();

            return View(products);
        }
        public IActionResult ViewDepartment(int id)
        {
            var repo = new DepartmentsRepository();
            var depo = repo.ViewDepartment(id);

            if (depo == null)
            {
                return View("Department not found"); 
            }
            return View(depo);
        }  


    }
}