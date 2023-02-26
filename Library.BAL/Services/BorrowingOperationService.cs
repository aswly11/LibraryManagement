using AutoMapper;
using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.BAL.Services
{
    public class BorrowingOperationService : IBorrowingOperationService
    {
        private readonly IGenericRepository<BorrowingOperation> _iBorrowingOperationRepository;
        private readonly IGenericRepository<Book> _iBookRepository;
        private readonly IMapper _mapper;

        public BorrowingOperationService(IGenericRepository<BorrowingOperation> iBorrowingOperationRepository, IMapper mapper, IGenericRepository<Book> iBookRepository)
        {
            _iBorrowingOperationRepository = iBorrowingOperationRepository;
            _mapper = mapper;
            _iBookRepository = iBookRepository;
        }


        public IEnumerable<BorrowingOperation> GetAll()
        {
            return _iBorrowingOperationRepository.GetAll();
        }

        public BorrowingOperation GetById(int id)
        {
            return _iBorrowingOperationRepository.GetById(id);
        }

        public void Insert(BorrowingOperationDTO BorrowingOperationDto)
        {

            var BorrowingOperation = _mapper.Map<BorrowingOperation>(BorrowingOperationDto);
            _iBorrowingOperationRepository.Insert(BorrowingOperation);
            _iBorrowingOperationRepository.Save();
            var book = _iBookRepository.GetByIdAsNoTracking(BorrowingOperation.BookId);
            book.IsBorrowed= true;
            _iBookRepository.Update(book);
            _iBookRepository.Save();
        }

        public void Update(BorrowingOperationDTO BorrowingOperationDto)
        {
            var BorrowingOperation = _mapper.Map<BorrowingOperation>(BorrowingOperationDto);
            _iBorrowingOperationRepository.Update(BorrowingOperation);
            _iBorrowingOperationRepository.Save();
        }
        public void Delete(int id)
        {
            _iBorrowingOperationRepository.Delete(id);
            _iBorrowingOperationRepository.Save();
        }

        public BorrowingOperation GetByIdAsNoTracking(int id)
        {
            return _iBorrowingOperationRepository.GetByIdAsNoTracking(id);
        }

        public bool IsBorrowed(int BookId)
        {


            return _iBookRepository.GetByIdAsNoTracking(BookId).IsBorrowed;

        }
    }
}
