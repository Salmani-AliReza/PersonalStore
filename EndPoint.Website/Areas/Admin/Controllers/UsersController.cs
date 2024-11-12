using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Personal_Store.Application.Services.Users.Commands.RegisterUser;
using Personal_Store.Application.Services.Users.Commands.RemoveUser;
using Personal_Store.Application.Services.Users.Commands.UserStatusChange;
using Personal_Store.Application.Services.Users.Queries.GetRoles;
using Personal_Store.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;

        public UsersController(
            IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IUserStatusChangeService userStatusChangeService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
        }

        [HttpGet]
        public IActionResult Index(int page, string searchKey)
        {
            return View(_getUsersService.Execute(new RequestGetUsersDTO
            {
                SearchKey = searchKey,
                Page = page
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FirstName, string LastName, string Email,
            long roleID, string Phone, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDTO
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Roles = new List<RolesInRegisterUserDTO>()
                {
                    new RolesInRegisterUserDTO()
                    {
                        ID = roleID
                    }
                },
                Password = Password,
                RePassword = RePassword
            });
            return Json(result);
        }

        [HttpDelete]
        public IActionResult Delete(long userID)
        {
            var result = _removeUserService.Execute(userID);
            return Json(result);
        }

        [HttpPut]
        public IActionResult UserStatusChange(long userID)
        {
            return Json(_userStatusChangeService.Execute(userID));
        }
    }
}
