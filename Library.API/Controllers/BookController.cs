using Library.BAL.Services;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _BookService;

        public BookController(IBookService BookService)
        {
            _BookService = BookService;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_BookService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Book = _BookService.GetById(id);
            if (Book == null)
                return NotFound();

            return Ok(Book);

        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO Book)
        {
            _BookService.Insert(Book);
            return Ok(Book);

        }



        [HttpPut]
        public IActionResult Put([FromBody] BookDTO Book)
        {

            var Exist = _BookService.GetByIdAsNoTracking(Book.BookId);
            if (Exist == null)
            {
                return NotFound("Book Not found");

            }

            _BookService.Update(Book);
            return Ok(Book);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _BookService.Delete(id);
            return Ok(id);

        }
    }
}
