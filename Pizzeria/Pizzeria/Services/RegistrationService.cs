using Pizzeria.Models;
using System.Text.RegularExpressions;

namespace Pizzeria.Services
{
    public class RegistrationService
    {
        private readonly ApplicationDbContext _db;
        private readonly EmailMassageService _emailMassageService;
        public RegistrationService(ApplicationDbContext db)
        {
            _db = db;
            _emailMassageService = new EmailMassageService();
        }
        public int FindIdCocker()
        {
            List<Worker> cockers = _db.Workers.ToList();
            var numbers = cockers
                    .SelectMany(w => Regex.Matches(w.IDWorker, @"\bCok\d+\b")
                    .Cast<Match>()
                    .Select(match => int.Parse(match.Value.Substring(3)))); // 3 - длина "Cok"

            // Находим максимальное число
            return numbers.DefaultIfEmpty().Max();
        }
        public int FindIdManager()
        {
            List<Worker> cockers = _db.Workers.ToList();
            var numbers = cockers
                    .SelectMany(w => Regex.Matches(w.IDWorker, @"\bMan\d+\b")
                    .Cast<Match>()
                    .Select(match => int.Parse(match.Value.Substring(3)))); // 3 - длина "Cok"

            // Находим максимальное число
            return numbers.DefaultIfEmpty().Max();
        }
        public int FindIdDirector()
        {
            List<Worker> cockers = _db.Workers.ToList();
            var numbers = cockers
                    .SelectMany(w => Regex.Matches(w.IDWorker, @"\bDir\d+\b")
                    .Cast<Match>()
                    .Select(match => int.Parse(match.Value.Substring(3)))); // 3 - длина "Cok"

            // Находим максимальное число
            return numbers.DefaultIfEmpty().Max();
        }

        public void AddWorkerCocker(Cocker CoKer)
        {
            var workerToDelete = _db.Workers.Find("Cok" + FindIdCocker().ToString());
            if(CoKer.ExperienceYears == null)
            {
                CoKer.ExperienceYears = 0;
            }
            if(CoKer.Specialization == null)
            {
                CoKer.Specialization = "New Cock";
            }
            var newCocker = new Cocker
            {
                IDWorker = "Cok" + FindIdCocker().ToString(),
                WorkerName = workerToDelete.WorkerName,
                WorkerSurname = workerToDelete.WorkerSurname,
                WorkerEmail = workerToDelete.WorkerEmail,
                WorkerPassword = workerToDelete.WorkerPassword,
                WorkerPhone = workerToDelete.WorkerPhone,
                Specialization = char.ToUpper(CoKer.Specialization[0]) + CoKer.Specialization.Substring(1),
                ExperienceYears = CoKer.ExperienceYears,
                HasFoodSafetyTraining = CoKer.HasFoodSafetyTraining
            };


            if (workerToDelete != null)
            {
                _db.Workers.Remove(workerToDelete);
                _db.SaveChanges();
            }
            _db.Cockers.Add(newCocker);
            _db.SaveChanges();
            _emailMassageService.SendEmail(newCocker.WorkerEmail, newCocker.WorkerName, "Ура!!", "Поздравляю вас приняли на работу!");
        }

        public void AddWorkerManager(Manager manager)
        {
            var workerToDelete = _db.Workers.Find("Man" + FindIdManager().ToString());
            if (manager.Department == null)
            {
                manager.Department = "New Manager";
            }
            var newManager = new Manager
            {
                IDWorker = "Man" + FindIdManager().ToString(),
                WorkerName = workerToDelete.WorkerName,
                WorkerSurname = workerToDelete.WorkerSurname,
                WorkerEmail = workerToDelete.WorkerEmail,
                WorkerPassword = workerToDelete.WorkerPassword,
                WorkerPhone = workerToDelete.WorkerPhone,
                Department = char.ToUpper(manager.Department[0]) + manager.Department.Substring(1),
                HasLeadershipTraining = manager.HasLeadershipTraining
            };


            if (workerToDelete != null)
            {
                _db.Workers.Remove(workerToDelete);
                _db.SaveChanges();
            }
            _db.Managers.Add(newManager);
            _db.SaveChanges();
            _emailMassageService.SendEmail(newManager.WorkerEmail, newManager.WorkerName, "Ура!!", "Поздравляю вас приняли на работу!");
        }
        public void AddWorkerDirector(Director director)
        {
            var workerToDelete = _db.Workers.Find("Dir" + FindIdDirector().ToString());
            if (director.Department == null)
            {
                director.Department = "New Director";
            }
            var newDirecor = new Director
            {
                IDWorker = "Dir" + FindIdDirector().ToString(),
                WorkerName = workerToDelete.WorkerName,
                WorkerSurname = workerToDelete.WorkerSurname,
                WorkerEmail = workerToDelete.WorkerEmail,
                WorkerPassword = workerToDelete.WorkerPassword,
                WorkerPhone = workerToDelete.WorkerPhone,
                Department = char.ToUpper(director.Department[0]) + director.Department.Substring(1),
                HasLeadershipExperience = director.HasLeadershipExperience
            };


            if (workerToDelete != null)
            {
                _db.Workers.Remove(workerToDelete);
                _db.SaveChanges();
            }
            _db.Derectors.Add(newDirecor);
            _db.SaveChanges();
            _emailMassageService.SendEmail(newDirecor.WorkerEmail, newDirecor.WorkerName, "Ура!!", "Поздравляю вас приняли на работу!");
        }


        public void AddWorker(RegistrationInfo registrationInfo, string id)
        {
            var newWorker = new Worker
            {
                IDWorker = id,
                WorkerName = char.ToUpper(registrationInfo.WorkerName[0]) + registrationInfo.WorkerName.Substring(1),
                WorkerSurname = char.ToUpper(registrationInfo.WorkerSurname[0]) + registrationInfo.WorkerSurname.Substring(1),
                WorkerPhone = char.ToUpper(registrationInfo.WorkerPhone[0]) + registrationInfo.WorkerPhone.Substring(1),
                WorkerEmail = registrationInfo.WorkerEmail,
                //WorkerPost = char.ToUpper(registrationInfo.WorkerPost[0]) + registrationInfo.WorkerPost.Substring(1),
                WorkerPassword = registrationInfo.WorkerPassword

            };
            _db.Workers.Add(newWorker);
            _db.SaveChanges();
        }

    }
}
 