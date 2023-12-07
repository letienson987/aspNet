using FilmApp.WebServiceCore.Entities;
using FilmApp.WebServiceCore.Services;
using FilmApp.WebServiceModel.RequestModels;
//using FilmApp.WebServiceModels.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FilmApp.WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var users = await _service.GetByIdAsync(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsersRequestModel item)
        {

            await _service.CreateAsync(item);
            return Created(string.Empty, (object)null);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Edit(int id, [FromBody] UsersRequestModel item)
        //{
        //    try
        //    {
        //        await _service.UpdateAsync(item, id);
        //        return Accepted();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _service.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}