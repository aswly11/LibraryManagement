using LibraryManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        Category GetByIdAsNoTracking(int id);
        void Insert(Category user);
        void Update(Category user);
        void Delete(int id);
    }
}
