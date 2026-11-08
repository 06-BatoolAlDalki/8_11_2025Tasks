using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication57.Data;
using WebApplication57.Models;

namespace WebApplication57.Controllers
{
    public class MangersNewController : Controller
    {
        private readonly ApplicationDbContext _context;  // call to dbcontect === database

        public MangersNewController(ApplicationDbContext context)
        {
            _context = context; // object of database , CRUD on the database

        }

        public IActionResult Index()
        {
            var managers = _context.managers.ToList();
            //select * from Managers

            return View(managers);// list of managers 
        }


        [HttpGet]
        public IActionResult Create() // Dispaly only form 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Manager manager) // take data from form and save in the database 
        {
            _context.managers.Add(manager); // insert into Managers values (name)
            _context.SaveChanges(); // commit the changes in the database
            return  RedirectToAction("Index");
        }
    }

}
