using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Pizzeria.Models;
using Pizzeria.Services;
using System.Text.RegularExpressions;

namespace Pizzeria.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RegistrationInfo registrationInfo { get; set; }
        public ValidModelService _validModelService { get; set; }
        public Cocker coKer { get; set; }
        public RegistrationService _registrationService { get; set; }
        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;
            _registrationService = new RegistrationService(db);
            _validModelService = new ValidModelService(db);
            coKer = new Cocker();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ActionName("NewIndex")]
        public IActionResult Index(RegistrationInfo registrationInfo, List<string> post)
        {
            if (!_validModelService.ValidRegistrationInfoModel(registrationInfo, ModelState))
            {
                return View("Index",registrationInfo);
            }
            foreach (var filling in post)
            {
                if(filling == "Cock")
                {
                    _registrationService.AddWorker(registrationInfo, "Cok" + (_registrationService.FindIdCocker()+1).ToString());
                    return View("NewCock");

                }
                if(filling == "Manager")
                {
                    _registrationService.AddWorker(registrationInfo, "Man" + (_registrationService.FindIdManager() + 1).ToString());
                    return View("NewManager");
                }
                else
                {
                    _registrationService.AddWorker(registrationInfo, "Dir" + (_registrationService.FindIdDirector() + 1).ToString());
                    return View("NewDirector");
                }
            }
            if(post.Count == 0)
            {
                _registrationService.AddWorker(registrationInfo, "Cok" + (_registrationService.FindIdCocker() + 1).ToString());
                return View("NewCock");
            }



            return Redirect("/Workers/Index");
            
            
        }

        
        [HttpPost]
        public IActionResult NewCock()
        {
            Cocker CoKer = new Cocker();
            return View(CoKer);
        }
        [HttpPost]
        [ActionName("NewCockAdd")]
        public IActionResult NewCock(Cocker CoKer)
        {
            _registrationService.AddWorkerCocker(CoKer);
           
            return Redirect("/Workers/Index");
        }
        [HttpPost]
        public IActionResult NewManager()
        {
            Manager ManAger = new Manager();
            return View(ManAger);
        }
        [HttpPost]
        [ActionName("NewManagerAdd")]
        public IActionResult NewManager(Manager ManAger)
        {
            _registrationService.AddWorkerManager(ManAger);

            return Redirect("/Workers/Index");
        }
        public IActionResult NewDirector()
        {
            Director director = new Director();
            return View(director);
        }
        [HttpPost]
        [ActionName("NewDirectorAdd")]
        public IActionResult NewDirector(Director director)
        {
            _registrationService.AddWorkerDirector(director);

            return Redirect("/Workers/Index");
        }


    }
}
