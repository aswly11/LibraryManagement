using Library.BAL.Services;
using LibraryManagement.DAL.Models;
using LibraryManagement.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUserService _userService;

        public  UsersController(IUserService userService) 
        {
           
            _userService = userService;

        }
        [HttpGet]
        public IActionResult Get() {

          return Ok(_userService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            if(user ==null)
                return NotFound();  

            return Ok(user);

        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _userService.Insert(user);
            return Ok(user);

        }



        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            var Exist = _userService.GetByIdAsNoTracking(user.UserId);
            if(Exist==null)
            {
                return NotFound("User Not found");

            }

            _userService.Update(user);
            return Ok(user);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _userService.Delete(id);
            return Ok(id);

        }
    }
}
