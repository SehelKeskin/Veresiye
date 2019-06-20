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

        public RegisterStatus Register(User user)
        {
            user.UserName = user.UserName.ToLower();

            //Validasyonlar
           if (string.IsNullOrEmpty(user.UserName))
            {
                return RegisterStatus.InvalidFields;
            }
            else
            {//veritabanında böyle bir kullanıcı var mı diye baktık!.
                var newUser = userRepository.Get(x=>x.UserName== user.UserName);
                if (newUser!=null)
                {
                    return RegisterStatus.UserAlreadyExists;
                }
            }

            //var newUser = new User();
            //newUser.UserName = user.UserName;
            //newUser.Password = user.Password;
           
            userRepository.Insert(user);
            unitOfWork.SaveChanges();
            return RegisterStatus.Success;
        }

      
    }

    public interface IUserService
    {
        User Login(string userName,string password);
        RegisterStatus Register(User user);
        IEnumerable<User> GetAll();
      

    }

    public enum RegisterStatus
    {
        Success=1,
        InvalidFields=2,
        UserAlreadyExists=3
    }


}
