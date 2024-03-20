using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pizzeria.Models;

namespace Pizzeria.Services
{
    public class ValidModelService : ValidService
    {

        public ValidModelService(ApplicationDbContext db):base(db)
        {
            
        }

        public bool ValidWorkerModel(Worker worker, ModelStateDictionary modelState)
        {
            bool index = true;
            
                if (worker.WorkerName!= null && !IsValidName(worker.WorkerName))
                {
                    modelState.AddModelError("WorkerName", "The name must adhere to certain rules.");
                    index = false;
                }
                if (worker.WorkerSurname != null && !IsValidSurname(worker.WorkerSurname))
                {
                    modelState.AddModelError("WorkerSurname", "The surname must adhere to certain rules.");
                    index = false;
                }
                if (worker.WorkerPhone != null && worker.WorkerPhone != null && !IsValidPhone(worker.WorkerPhone))
                {
                    modelState.AddModelError("WorkerPhone", "Invalid data format.");
                    index = false;
                }
                
               /* if (worker.WorkerPost != null && !IsValidPost(worker.WorkerPost))
                {
                    modelState.AddModelError("WorkerPost", "The post must adhere to certain rules.");
                    index = false;
                }*/
                if (worker.WorkerPassword != null && !IsValidPassword(worker.WorkerPassword))
                {
                    modelState.AddModelError("WorkerPost", "Invalid data format");
                    index = false;
                }
                if (worker.WorkerEmail != null && !IsValidEmail(worker.WorkerEmail))
                {
                        modelState.AddModelError("WorkerEmail", "Invalid data format.");
                        index = false;
                }


            return index;
           
        }
        public bool ValidRegistrationInfoModel(RegistrationInfo registrationInfo, ModelStateDictionary modelState)
        {
            bool index = true;

            if (registrationInfo.WorkerName != null && !IsValidName(registrationInfo.WorkerName))
            {
                modelState.AddModelError("WorkerName", "The name must adhere to certain rules.");
                index = false;
            }
            if (registrationInfo.WorkerSurname != null && !IsValidSurname(registrationInfo.WorkerSurname))
            {
                modelState.AddModelError("WorkerSurname", "The surname must adhere to certain rules.");
                index = false;
            }
            if (registrationInfo.WorkerPhone != null)
            {
                if (IsValidPhone(registrationInfo.WorkerPhone))
                {
                    foreach (Worker worker in _db.Workers)
                    {
                        if (worker.WorkerPhone == registrationInfo.WorkerPhone) { modelState.AddModelError("WorkerPhone", "This phone is already in use."); index = false; break; }
                        else if(index != false)index = true;
                    }
                    
                }
                else
                {
                    modelState.AddModelError("WorkerPhone", "Invalid data format.");
                                    index = false;
                }
                
            }
            if (registrationInfo.WorkerEmail != null )
            {
                if (IsValidEmail(registrationInfo.WorkerEmail))
                {
                    foreach (Worker worker in _db.Workers)
                    {
                        if (worker.WorkerEmail == registrationInfo.WorkerEmail) { modelState.AddModelError("WorkerEmail", "This email is already in use."); index = false; break; }
                        else if (index != false) index = true;
                    }
                }
                else
                {
                    modelState.AddModelError("WorkerEmail", "Invalid data format.");
                    index = false;
                }
                
            }
            
            if (registrationInfo.WorkerPassword != null && !IsValidPassword(registrationInfo.WorkerPassword))
            {
                modelState.AddModelError("WorkerPassword", "Invalid data format");
                index = false;
            }
            if (!IsValidDuplicatePassword(registrationInfo.WorkerDuplicatePassword, registrationInfo.WorkerPassword))
            {
                modelState.AddModelError("WorkerDuplicatePassword", "Passwords do not match.");
                index = false;
            }


            return index;

        }
    }
}