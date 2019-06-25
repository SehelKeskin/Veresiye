using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Data;
using Veresiye.Model;

namespace Veresiye.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;//kaydetme yapacaksın.
        private readonly IRepository<Company> CompanyRepository;//Ekleme güncelleme yapacaksın.

        public CompanyService(IUnitOfWork unitOfWork, IRepository<Company> companyRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CompanyRepository = companyRepository;

        }
        public void Delete(int id)
        {
            var company = CompanyRepository.Get(id);
            if (company!=null)
            {
                CompanyRepository.Delete(company);
                unitOfWork.SaveChanges();

            }
            
        }

        public Company Get(int id)
        {
            return CompanyRepository.Get(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return CompanyRepository.GetAll();
        }

        public void Insert(Company company)
        {
            CompanyRepository.Insert(company);
            unitOfWork.SaveChanges();
        }

      
        public void Update(Company company)
        {
            CompanyRepository.Update(company);
            unitOfWork.SaveChanges();
        }
    }
    public interface ICompanyService
    {
        //CRUT işlemerine göre düşün burayı.

        void Insert(Company company);
        void Update(Company company);
        void Delete(int id);
        IEnumerable<Company> GetAll();
      
        Company Get(int id);
    }
}
