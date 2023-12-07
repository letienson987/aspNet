using FilmApp.WebServiceCore.Services;
using FilmApp.WebServiceModels.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmApp.WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page, [FromQuery] int itemPerPage)
        {
            var categories = await _service.GetAllAsync(page, itemPerPage);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequestModel item)
        {
            
            await _service.CreateAsync(item);
            return Created(string.Empty, (object)null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] CategoryRequestModel item)
        {
            try
            {
                await _service.UpdateAsync(item, id);
                return Accepted();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
