using Library.BAL.Services;
using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingOperationController : ControllerBase
    {
        private readonly IBorrowingOperationService _BorrowingOperationService;

        public BorrowingOperationController(IBorrowingOperationService BorrowingOperationService)
        {
            _BorrowingOperationService = BorrowingOperationService;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_BorrowingOperationService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var BorrowingOperation = _BorrowingOperationService.GetById(id);
            if (BorrowingOperation == null)
                return NotFound();

            return Ok(BorrowingOperation);

        }

        [HttpPost]
        public IActionResult Post([FromBody] BorrowingOperationDTO BorrowingOperation)
        {

            if(_BorrowingOperationService.IsBorrowed(BorrowingOperation.BookId))
            {
                return BadRequest("This Book Is Borrowed Right now ");
            }

            _BorrowingOperationService.Insert(BorrowingOperation);
            return Ok(BorrowingOperation);

        }


       
        [HttpPut]
        public IActionResult Put([FromBody] BorrowingOperationDTO BorrowingOperation)
        {

            var Exist = _BorrowingOperationService.GetByIdAsNoTracking(BorrowingOperation.BorrowingOperationId);
            if (Exist == null)
            {
                return NotFound("BorrowingOperation Not found");

            }

            _BorrowingOperationService.Update(BorrowingOperation);
            return Ok(BorrowingOperation);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _BorrowingOperationService.Delete(id);
            return Ok(id);

        }
    }
}
