using Microsoft.AspNetCore.Mvc;
using WebApplication57.Data;
using WebApplication57.Models;

namespace WebApplication57.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManagerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var mangers= _context.managers.ToList();
            return View(mangers);
        }


        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }



        [HttpPost]
        public IActionResult Create(Manager manager)
        {
            var newManger = new Manager
            {
                Id = manager.Id,
                Name = manager.Name
            };
            _context.managers.Add(newManger);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manger = _context.managers.FirstOrDefault(m => m.Id == id);
            return View(manger);
        }

        [HttpPost]
        public IActionResult Edit(int id , Manager manager)
        {
           // var oldmanger = _context.managers.FirstOrDefault(m => m.Id == id);
           // manager.Name = oldmanger.Name;
            _context.managers.Update(manager);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
             var oldmanger = _context.managers.FirstOrDefault(m => m.Id == id);
            // manager.Name = oldmanger.Name;
            _context.managers.Remove(oldmanger);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
