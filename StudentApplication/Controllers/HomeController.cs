using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {

        StudentContext studentContext;

        public HomeController(StudentContext context)
        {
            studentContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowStudent()
        {
            var students = studentContext.students.ToList();
            return View(students);
        }

        public IActionResult Detay(int id)
        {
            Student student = studentContext.students.Where(s => s.Id == id).FirstOrDefault();
            if (student != null)
            {
                return View(student);
            } else
            {
                
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
