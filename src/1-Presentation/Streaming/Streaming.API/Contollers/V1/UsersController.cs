using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streaming.Application.Utilities.Extensions;
using Streaming.Business.Interfaces;
using Streaming.Entities.Concrete;

namespace Streaming.API.Contollers.V1
{
    [ApiVersion("1")]
    [ApiController]
    [Route("v1")]
    [Authorize]
    public class UsersController : Controller
    {
        
        private readonly IUserService _usersService;

        public UsersController(IUserService UsersService)
        {
            _usersService = UsersService;
        }

        [HttpPost("AddUser")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] User Users)
        {
            var result = _usersService.Add(Users);
            return result.IsSuccess
                ? CreatedAtAction(nameof(Add), new { id = Users.Id, users = Users })
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("UpdateUser/{id:int:min(1)}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] User Users)
        {
            Users.Id = id;
            var result = _usersService.Update(Users);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("DeleteByIdUser/{id:int:min(1)}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _usersService.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }
    }
}
