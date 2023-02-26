using AutoMapper;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Models.DTOs;


namespace LibraryManagement.DAL
{
    public class AutoMapperProfileConfiguration:Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<BorrowingOperationDTO, BorrowingOperation>();
        }
    }
}
