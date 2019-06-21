using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Data;
using Veresiye.Model;

namespace Veresiye.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork unitOfWork;//kaydetme yapacaksın.
        private readonly IRepository<Activity> ActivityRepository;//Ekleme güncelleme yapacaksın.

        public ActivityService(IUnitOfWork unitOfWork, IRepository<Activity> activityRepository)
        {
            this.unitOfWork = unitOfWork;
            this.ActivityRepository = activityRepository;

        }
        public void Delete(int id)
        {
            var activity = ActivityRepository.Get(id);
            if (activity != null)
            {
                ActivityRepository.Delete(activity);
                unitOfWork.SaveChanges();

            }

        }
        public IEnumerable<Activity> GetAllByCompanyId(int companyId)
        {
            return ActivityRepository.GetAll(x => x.CompanyId == companyId);
        }
        public Activity Get(int id)
        {
            return ActivityRepository.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return ActivityRepository.GetAll();
        }

        public void Insert(Activity activity)
        {
            ActivityRepository.Insert(activity);
            unitOfWork.SaveChanges();
        }

        public void Update(Activity activity)
        {
            ActivityRepository.Update(activity);
            unitOfWork.SaveChanges();
        }
    }
    public interface IActivityService
    {
        //CRUT işlemerine göre düşün burayı.

        void Insert(Activity activity);
        void Update(Activity activity);
        void Delete(int id);
        IEnumerable<Activity> GetAll();
        Activity Get(int id);
        IEnumerable<Activity> GetAllByCompanyId(int companyId);
    }

}
