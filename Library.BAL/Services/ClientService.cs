using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class ClientService:IClientService
    {
        private readonly IGenericRepository<Client> _iClientRepository;
        public ClientService(IGenericRepository<Client> iClientRepository)
        {
            _iClientRepository = iClientRepository;
        }


        public IEnumerable<Client> GetAll()
        {
            return _iClientRepository.GetAll().Include(x=>x.BorrowingOperations);
        }

        public Client GetById(int id)
        {
            return _iClientRepository.GetById(id);
        }

        public void Insert(Client user)
        {
            _iClientRepository.Insert(user);
            _iClientRepository.Save();
        }

        public void Update(Client user)
        {
            _iClientRepository.Update(user);
            _iClientRepository.Save();
        }
        public void Delete(int id)
        {
            _iClientRepository.Delete(id);
            _iClientRepository.Save();
        }

        public Client GetByIdAsNoTracking(int id)
        {

            return _iClientRepository.GetByIdAsNoTracking(id);

        }
    }
}
