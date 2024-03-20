namespace Pizzeria.Services
{
    public class IWorkerService
    {
        private readonly ApplicationDbContext _db;
        public IWorkerService(ApplicationDbContext db) {  _db = db; }

    }
}
