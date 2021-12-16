using Application.Users.Commands.DeleteUserById;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserById;
using CleanArc.Application.Services.Users.Commands.CreateUser;
using CleanArc.Application.Services.Users.Queries.GetEmailUnique;
using CleanArc.Application.Services.Users.Queries.GetUserDetails;
using CleanArc.Application.Services.Users.Queries.GetUserNameUnique;
using CleanArc.Application.Services.Users.Queries.GetUserPasswordValidation;
using CleanArc.Application.Services.Users.Queries.GetUserProjectsList;
using CleanArc.Application.Services.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("users")]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
            //return await ViewAsync("~/Views/Project/Create.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserCreateViewModel vm)
        {
            
            var path = "\\Create";
            if (ModelState.IsValid)
            {
                if(await Mediator.Send(new GetEmailUniqueQuery() { Email = vm.Email }))
                {
                    ModelState.AddModelError("Email", "This email is used");
                    return await this.CreateJsonNotValidResultViewAsync(path, vm, ModelState);
                }
                else if (await Mediator.Send(new GetUserNameUniqueQuery() { UserName = vm.UserName, Id = null }))
                {
                    ModelState.AddModelError("UserName", "This Username already is used");
                    return await this.CreateJsonNotValidResultViewAsync(path, vm, ModelState);
                }
                await Mediator.Send(new CreateUserCommand() { Model = vm });
                return await this.CreateJsonResultViewAsync(path);
            }
            ModelState.AddModelError("", "Fill all fields please");
            return await this.CreateJsonNotValidResultViewAsync(path, vm);

        }

        [HttpGet]
        [Route("Upsert/{id}")]
        public async Task<IActionResult> Upsert(Guid id)
        {
            var vm = (await Mediator.Send(new GetUserByIdQuery() { Id = id })).ResponseValue;
            ViewBag.Model = vm;
            return View("~/Views/User/Edit.cshtml");
        }

        [HttpPost]
        [Route("Upsert")]
        public async Task<IActionResult> Upsert([FromForm] UserUpdateViewModel vm)
        {
            var path = "\\Edit";
            dynamic bag = new ExpandoObject();
            bag.Model = vm;
            if (ModelState.IsValid)
            {
                if (await Mediator.Send(new GetUserNameUniqueQuery() { UserName = vm.UserName, Id = vm.Id }))
                {
                    ModelState.AddModelError("UserName", "This Username already is used");
                    return await this.CreateJsonNotValidResultViewAsync(path, vm, ModelState, bag);
                }

                await Mediator.Send(new UpdateUserCommand() { Model = vm });
                return await this.CreateJsonResultViewAsync(path, vm, ModelState, bag );
            }
            ModelState.AddModelError("", "Fill all fields please");
            return await this.CreateJsonNotValidResultViewAsync(path, vm);
        }


        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var vm = (await Mediator.Send(new GetUserDetailsQuery() { Id = id })).ResponseValue;


            ViewBag.Model = vm;
            return View("~/Views/User/Details.cshtml");
        }



        [HttpDelete]
        [Route("DeleteConfirmation/{id}")]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            ViewBag.Model = new DeleteUserViewModel() { Id = id};
            return View("~/Views/User/Delete.cshtml");
        }

        [HttpPost]
        [Route("DeleteConfirmation")]
        public async Task<IActionResult> Delete([FromForm] DeleteUserViewModel vm)
        {
            dynamic bag = new ExpandoObject();
            bag.Model = vm;
            var path = "\\Delete";
            if (ModelState.IsValid)
            {
                var num = await Mediator.Send(new GetUserProjectsNumberQuery() { Id = vm.Id });
                if (num > 0 )
                {
                    ModelState.AddModelError("", "Cant Delete user that is working on "  + num + " projects.");
                    return await this.CreateJsonNotValidResultViewAsync(path, vm, ModelState, bag);
                }
                await Mediator.Send(new DeleteUserByIdCommand() { Id = vm.Id });
                return await this.CreateJsonResultViewAsync(path, vm, ModelState, bag);
            }
            ModelState.AddModelError("", "Validation Error");
            return await this.CreateJsonNotValidResultViewAsync(path, vm, ModelState);

        }
    }
}
