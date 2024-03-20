using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class WorkerDbService
    {
        private readonly ApplicationDbContext _db;
        public WorkerDbService(ApplicationDbContext db) {  _db = db; }
        public Worker GetWorker(string workerId)
        {
            return _db.Workers.Find(workerId);
        }
    }
}
