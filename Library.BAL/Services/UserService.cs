using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class UserService:IUserService
    {
        private readonly IGenericRepository<User> _iUserRepository;
        public UserService(IGenericRepository<User> iUserRepository) {
            _iUserRepository = iUserRepository;
        }

       
        public IEnumerable<User> GetAll()
        {
           return _iUserRepository.GetAll();
        }

        public User GetById(int id)
        {
           return _iUserRepository.GetById(id);
        }

        public void Insert(User user)
        {
            _iUserRepository.Insert(user);
            _iUserRepository.Save();
        }

        public void Update(User user)
        {
            _iUserRepository.Update(user);
            _iUserRepository.Save();
        }
        public void Delete(int id)
        {
            _iUserRepository.Delete(id);
            _iUserRepository.Save();
        }

        public User GetByIdAsNoTracking(int id)
        {
            return _iUserRepository.GetByIdAsNoTracking(id);
        }
    }
}
