using LibraryManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByIdAsNoTracking(int id);
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
       
    }
}
