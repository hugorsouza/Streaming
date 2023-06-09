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
    public class SeriesController : Controller
    {
        private readonly ISeriesService _SeriesService;

        public SeriesController(ISeriesService SeriesService)
        {
            _SeriesService = SeriesService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] int? categoryId)
        {
            var Series = categoryId == null
                ? _SeriesService.FindAll()
                : _SeriesService.FindAllByCategoryId(categoryId.Value);
            return Ok(Series);
        }

        [HttpGet("GetSeriesById{id:int:min(1)}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Series = _SeriesService.FindById(id);
            return Series == null ? this.FailedNotFound(nameof(Series), (nameof(id), id)) : Ok(Series);
        }

        [HttpPost("AddSeries")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] Series Series)
        {
            var result = _SeriesService.Add(Series);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = Series.Id }, Series)
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("UpdateSeries/{id:int:min(1)}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] Series Series)
        {
            Series.Id = id;
            var result = _SeriesService.Update(Series);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("DeleteByIdSeries/{id:int:min(1)}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _SeriesService.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

    }
}

