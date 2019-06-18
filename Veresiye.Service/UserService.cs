using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veresiye.Data;
using Veresiye.Model;

namespace Veresiye.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> userRepository;
        public UserService(IUnitOfWork unitOfWork,IRepository<User> userRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User Login(string userName, string password)
        {
         userName=   userName.ToLower();
            var user = userRepository.Get(x => x.UserName == userName && x.Password == password);
            return user;
        }

        public bool Register(string userName, string password, string conFirmPassword)
        {
            userName = userName.ToLower();

            //Validasyonlar
            if (password != conFirmPassword)//şifre tekrarı eşit değilse çık.

            {
                return false;
            }
            else if (string.IsNullOrEmpty(userName))
            {
                return false;
            }
            else
            {
                var user = userRepository.Get(x=>x.UserName==userName);
                if (user!=null)
                {
                    return false;
                }
            }

            var newUser = new User();
            newUser.UserName = userName;
            newUser.Password = password;
            userRepository.Insert(newUser);
            unitOfWork.SaveChanges();
            return true;
        }

        bool IUserService.Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserService
    {
        bool Login(string userName,string password);
        bool Register(string userName, string password, string conFirmPassword);
        IEnumerable<User> GetAll();

    }



}
