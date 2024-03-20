using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;
using Pizzeria.Services;

namespace Pizzeria.Controllers
{
    public class EditWorkerController : Controller
    {
        private readonly ApplicationDbContext _db;
        static WorkerDbService _workerDbService { get; set; }
        public ValidModelService _validModelService { get; set; }
        public EditWorkerController(ApplicationDbContext db)
        {
            _db = db;
            _workerDbService = new WorkerDbService(_db);
            _validModelService = new ValidModelService(db);
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ToEditWorker(string workerId)
        {
            var workerToEdit = _workerDbService.GetWorker(workerId);
            return View("Index", workerToEdit);
        }

        [HttpPost]
        [ActionName("ToEditWorkerByObject")]
        public IActionResult ToEditWorker(Worker worker)
        {
            if (!_validModelService.ValidWorkerModel(worker, ModelState))
            {
                return View("Index", worker);
            }
            
            var workerToEdit = _db.Workers.Find(worker.IDWorker);
            workerToEdit.WorkerName = char.ToUpper(worker.WorkerName[0]) + worker.WorkerName.Substring(1); ;
            workerToEdit.WorkerSurname = char.ToUpper(worker.WorkerSurname[0]) + worker.WorkerSurname.Substring(1);
            workerToEdit.WorkerPhone = worker.WorkerPhone;
            //workerToEdit.WorkerPost = char.ToUpper(worker.WorkerPost[0]) + worker.WorkerPost.Substring(1);
            workerToEdit.WorkerEmail = worker.WorkerEmail;
                _db.SaveChanges();
                return Redirect("/Workers/Index");
            
            
        }
        [HttpPost]
        public IActionResult DeleteWorker(string workerId)
        {
            
                var workerToDelete = _db.Workers.Find(workerId);
                if (workerToDelete != null)
                {
                    _db.Workers.Remove(workerToDelete);
                    _db.SaveChanges();
                }
            
            
            return Redirect("/Workers/Index");
        }
    }
}
