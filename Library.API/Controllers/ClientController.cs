using Library.BAL.Services;
using LibraryManagement.DAL.Models.DTOs;
using LibraryManagement.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }


        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_ClientService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Client = _ClientService.GetById(id);
            if (Client == null)
                return NotFound();

            return Ok(Client);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Client Client)
        {
            _ClientService.Insert(Client);
            return Ok(Client);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Client Client)
        {

            var Exist = _ClientService.GetByIdAsNoTracking(Client.ClientId);
            if (Exist == null)
            {
                return NotFound("Client Not found");

            }

            _ClientService.Update(Client);
            return Ok(Client);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _ClientService.Delete(id);
            return Ok(id);

        }
    }
}
