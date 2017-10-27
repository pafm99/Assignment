using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Assignment.Models;
using System.Linq;
//using Microsoft.Extensions.Logging;

namespace Assignment.Controllers
{
    public class DashboardController : Controller
    {
    private BeltsContext _context;
 
    public DashboardController(BeltsContext context)
    {
        _context = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            int? SessionId = HttpContext.Session.GetInt32("StudentId");
            if (SessionId == null){
                TempData["error"] = "Must be logged in to view this page";
                return RedirectToAction("Index", "Home");
            }
 
            List<Belt> AllBelts = _context.Belts.ToList();
            ViewBag.AllBelts = AllBelts; 
            return View();

        }


        [HttpPost]
        [Route("Process")]
        public IActionResult Process(BeltViewModel model)
        {
            if (ModelState.IsValid)
            {
                int? CurrStudentId = HttpContext.Session.GetInt32("StudentId");
                Belt NewBelt = new Belt{
                    Color = model.Color,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    StudentId = (int)CurrStudentId                  
                };
                    _context.Belts.Add(NewBelt);
                    _context.SaveChanges();
                    int BeltId = NewBelt.BeltId;
                    return Redirect("Index");
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");                
            }
        }
        [HttpGet]
        [Route("Display/{Id}")]
        public IActionResult Display(int id)
        {
            int? SessionId = HttpContext.Session.GetInt32("StudentId");
            if (SessionId == null){
                TempData["error"] = "Must be logged in to view this page";
                return RedirectToAction("Index", "Home");
            }            
            
            Belt currBelt = _context.Belts.Include(s => s.Student).SingleOrDefault(a => a.BeltId == id);
            ViewBag.currBelt = currBelt;
 
    
            return View("Display"); 
        }            

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(int Id, string BeltCategory, DateTime DateAchieved) {

            List<Belt> AllBelts = _context.Belts.ToList();
            ViewBag.AllBelts = AllBelts; 
            
            Belt currBelt = _context.Belts.Include(s => s.Student).SingleOrDefault(a => a.BeltId == Id);
            ViewBag.currBelt = currBelt;

            int? uId = HttpContext.Session.GetInt32("StudentId");
            if (uId == null) { 
                return RedirectToAction("Index", "Home");
            }
           
            Category newCategory = new Category {
                BeltId = Id,
                StudentId = (int)uId,
                DateAchieved = DateAchieved,
                BeltCategory = BeltCategory
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return View("Index");
        }


            
        

    }
}