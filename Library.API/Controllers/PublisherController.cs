using Library.BAL.Services;
using LibraryManagement.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private readonly IPublisherService _publisherService;

     
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_publisherService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
                return NotFound();

            return Ok(publisher);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            _publisherService.Insert(publisher);
            return Ok(publisher);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Publisher publisher)
        {

            var Exist = _publisherService.GetByIdAsNoTracking(publisher.PublisherId);
            if (Exist == null)
            {
                return NotFound("publisher Not found");

            }

            _publisherService.Update(publisher);
            return Ok(publisher);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _publisherService.Delete(id);
            return Ok(id);

        }
    }
}
