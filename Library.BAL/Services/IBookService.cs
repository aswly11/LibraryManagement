using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public  interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book GetByIdAsNoTracking(int id);

        void Insert(BookDTO Book);
        void Update(BookDTO Book);
        void Delete(int id);
    }
}
