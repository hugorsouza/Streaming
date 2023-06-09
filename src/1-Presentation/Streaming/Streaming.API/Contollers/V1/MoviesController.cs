using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Utilities.Extensions;
using Streaming.Business.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.API.Contollers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IMovieservice _Movieservice;

        public MoviesController(IMovieservice Movieservice)
        {
            _Movieservice = Movieservice;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] int? categoryId)
        {
            var Movies = categoryId == null
                ? _Movieservice.FindAll()
                : _Movieservice.FindAllByCategoryId(categoryId.Value);
            return Ok(Movies);
        }

        [HttpGet("GetMoviesById{id:int:min(1)}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Movies = _Movieservice.FindById(id);
            return Movies == null ? this.FailedNotFound(nameof(Movies), (nameof(id), id)) : Ok(Movies);
        }

        [HttpPost("AddMovies")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] Movies Movies)
        {
            var result = _Movieservice.Add(Movies);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = Movies.Id }, Movies)
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("UpdateMovies/{id:int:min(1)}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] Movies Movies)
        {
            Movies.Id = id;
            var result = _Movieservice.Update(Movies);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("DeleteByIdMovies/{id:int:min(1)}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _Movieservice.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

    }
}
