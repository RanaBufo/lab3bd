using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;
using Pizzeria.Services;
using System.Collections.Generic;

namespace Pizzeria.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AllWorker<Worker> allWorker;

        public WorkersController(ApplicationDbContext db)
        {
            allWorker = new AllWorker<Worker>();
            _db = db;
        }

        public IActionResult Index()
        {
            foreach(Cocker cockers in _db.Cockers)
            {
                allWorker.Add(cockers);
            }
            foreach (Director derector in _db.Derectors)
            {
                allWorker.Add(derector);
            }
            foreach (Manager manager in _db.Managers)
            {
                allWorker.Add(manager);
            }
            return View(allWorker);
        }

        
    }
}
