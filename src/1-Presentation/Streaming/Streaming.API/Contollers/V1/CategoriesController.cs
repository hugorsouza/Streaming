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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMovieservice _Movieservice;

        public CategoriesController(ICategoryService categoryService, IMovieservice Movieservice)
        {
            _categoryService = categoryService;
            _Movieservice = Movieservice;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var categories = _categoryService.FindAll();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById/{id:int:min(1)}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _categoryService.FindById(id);
            return category == null ? this.FailedNotFound(nameof(Category), (nameof(id), id)) : Ok(category);
        }

        [HttpGet("GetMoviesByIdCategory/{id:int:min(1)}")]
        public IActionResult GetMoviesById([FromRoute] int id)
        {
            var Movies = _Movieservice.FindAllByCategoryId(id);
            return Ok(Movies);
        }

        [HttpPost("AddCategory")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] Category category)
        {
            var result = _categoryService.Add(category);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = category.Id }, category)
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("UpdateCategory/{id}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] Category category)
        {
            category.Id = id;
            var result = _categoryService.Update(category);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("DeleteByIdCategory/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _categoryService.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

    }
}
