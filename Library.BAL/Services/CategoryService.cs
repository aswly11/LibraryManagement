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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _iCategoryRepository;
        public CategoryService(IGenericRepository<Category> iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }


        public IEnumerable<Category> GetAll()
        {
            return _iCategoryRepository.GetAll().Include(x=>x.Books).ToList();
        }

        public Category GetById(int id)
        {
            return _iCategoryRepository.GetById(id);
        }

        public void Insert(Category Category)
        {
            _iCategoryRepository.Insert(Category);
            _iCategoryRepository.Save();
        }

        public void Update(Category Category)
        {
            _iCategoryRepository.Update(Category);
            _iCategoryRepository.Save();
        }
        public void Delete(int id)
        {
            _iCategoryRepository.Delete(id);
            _iCategoryRepository.Save();
        }

        public Category GetByIdAsNoTracking(int id)
        {
            return _iCategoryRepository.GetByIdAsNoTracking(id);
        }
    }
}
