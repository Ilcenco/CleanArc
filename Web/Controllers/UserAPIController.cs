using Application.Users.Commands.DeleteUserById;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserById;
using Application.Users.Queries.GetUserDropDown;
using Application.Users.Queries.GetUserPage;
using CleanArc.Application.Services.Users.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace Web.Controllers
{
    [Route("api/users")]
    
    public class UserAPIController : BaseController
    {

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<JsonResult> UpdateUser([FromForm] UserUpdateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var reposne = await Mediator.Send(new UpdateUserCommand() { Model = model }) ;
                    return new JsonResult(reposne);
                }
            }
            catch(Exception)
            {
                throw;
            }
            return new JsonResult("Ok");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            
            return new JsonResult("Ok");
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<JsonResult> GetById([FromRoute] Guid id)
        {
            return new JsonResult(await Mediator.Send(new GetUserByIdQuery() { Id = id }));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<JsonResult> DeleteUser(Guid id)
        {
            return new JsonResult(await Mediator.Send(new DeleteUserByIdCommand() { Id = id }));
        }

        [HttpGet]
        [Route("GetDropDown")]
        public async Task<JsonResult> GetDropDown()
        {
            return new JsonResult(await Mediator.Send(new GetUserDropDownQuery()));
        }

        [HttpPost]
        [Route("GetPage")]
        public async Task<JsonResult> GetPage([FromForm] int pageSize, [FromForm] int pageIndex, [FromForm] string filter)
        {
            var response = await Mediator.Send(new GetUserPageQuery() { Filter = filter, PageIndex = pageIndex, PageSize = pageSize });
            return new JsonResult(response);
        }
        
    }
}
