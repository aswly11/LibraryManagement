using Library.BAL.Services;
using LibraryManagement.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

       
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_categoryService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _categoryService.Insert(category);
            return Ok(category);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {

            var Exist = _categoryService.GetByIdAsNoTracking(category.CategoryId);
            if (Exist == null)
            {
                return NotFound("category Not found");

            }

            _categoryService.Update(category);
            return Ok(category);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _categoryService.Delete(id);
            return Ok(id);

        }
    }
}
