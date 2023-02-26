using LibraryManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAll();
        Publisher GetById(int id); 
        Publisher GetByIdAsNoTracking(int id);
        
        void Insert(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);
    }
}
