using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace Library.BAL.Services
{
    public interface IBorrowingOperationService
    {
        IEnumerable<BorrowingOperation> GetAll();
        BorrowingOperation GetById(int id);
        BorrowingOperation GetByIdAsNoTracking(int id);

        void Insert(BorrowingOperationDTO BorrowingOperation);
        void Update(BorrowingOperationDTO BorrowingOperation);
        void Delete(int id);
        bool IsBorrowed(int BookId);
    }
}
