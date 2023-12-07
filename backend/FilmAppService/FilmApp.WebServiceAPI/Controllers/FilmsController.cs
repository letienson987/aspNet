using FilmApp.WebServiceCore.Services;
using FilmApp.WebServiceModel.RequestModels;
//using FilmApp.WebServiceModels.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmApp.WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/films")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService _service;

        public FilmsController(IFilmsService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int page, [FromQuery] int itemPerPage)
        {
            var films = await _service.GetAllAsync(page, itemPerPage);
            return Ok(films);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var films = await _service.GetByIdAsync(id);
            return Ok(films);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FilmsRequestModel item)
        {
            
            await _service.CreateAsync(item);
            return Created(string.Empty, (object)null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] FilmsRequestModel item)
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