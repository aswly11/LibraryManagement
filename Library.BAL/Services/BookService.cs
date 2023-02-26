using AutoMapper;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class BookService: IBookService
    {
        private readonly IGenericRepository<Book> _iBookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> iBookRepository, IMapper mapper)
        {
            _iBookRepository = iBookRepository;
            _mapper = mapper;
        }


        public IEnumerable<Book> GetAll()
        {
            return _iBookRepository.GetAll().Include(x => x.BorrowingOperations);
        }

        public Book GetById(int id)
        {
            return _iBookRepository.GetById(id);
        }

        public void Insert(BookDTO bookDto)
        {

            var book = _mapper.Map<Book>(bookDto);
            _iBookRepository.Insert(book);
            _iBookRepository.Save();
        }

        public void Update(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _iBookRepository.Update(book);
            _iBookRepository.Save();
        }
        public void Delete(int id)
        {
            _iBookRepository.Delete(id);
            _iBookRepository.Save();
        }

        public Book GetByIdAsNoTracking(int id)
        {
            return _iBookRepository.GetByIdAsNoTracking(id);
        }
    }
}
