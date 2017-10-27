using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;
using System.Linq;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
    private BeltsContext _context;
 
    public HomeController(BeltsContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = ModelState.Values;
            ViewBag.invalid = TempData["error"];
            return View();
        }

        [HttpPost]
        [Route("Register")]

        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student NewStudent = new Student{
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now                    
                };
                    _context.Students.Add(NewStudent);
                    _context.SaveChanges();

                    Student InSession = _context.Students.SingleOrDefault(user => user.Email == model.Email);
                    HttpContext.Session.SetInt32("StudentId", InSession.StudentId);
                   
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");                
            }
            return RedirectToAction("Index", "Dashboard"); 
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Student model)
        {
            Student currStudent = _context.Students.SingleOrDefault(u => u.Email == model.Email);
            if (currStudent.Password == model.Password)
            {
                HttpContext.Session.SetInt32("StudentId", currStudent.StudentId);

            }else{
                TempData["error"] = "Password/Email does not match";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

