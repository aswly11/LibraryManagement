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
    public class PublisherService : IPublisherService
    {
        private readonly IGenericRepository<Publisher> _iPublisherRepository;
        public PublisherService(IGenericRepository<Publisher> iPublisherRepository)
        {
            _iPublisherRepository = iPublisherRepository;
        }


        public IEnumerable<Publisher> GetAll()
        {
            return _iPublisherRepository.GetAll().Include(x=>x.Books).ToList();
        }

        public Publisher GetById(int id)
        {
            return _iPublisherRepository.GetById(id);
        }

        public void Insert(Publisher user)
        {
            _iPublisherRepository.Insert(user);
            _iPublisherRepository.Save();
        }

        public void Update(Publisher user)
        {
            _iPublisherRepository.Update(user);
            _iPublisherRepository.Save();
        }
        public void Delete(int id)
        {
            _iPublisherRepository.Delete(id);
            _iPublisherRepository.Save();
        }

        public Publisher GetByIdAsNoTracking(int id)
        {

            return _iPublisherRepository.GetByIdAsNoTracking(id);

        }
    }
}
