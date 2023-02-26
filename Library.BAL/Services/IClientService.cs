using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        Client GetByIdAsNoTracking(int id);

        void Insert(Client Client);
        void Update(Client Client);
        void Delete(int id);
    }
}
