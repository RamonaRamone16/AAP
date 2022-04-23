using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectA.BLL.Services;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models;
using ProjectA.Models.Models.Role;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SelectListService _selectListService;
        private readonly AccountService _accountService;
        public UserManagementController(
            UserManager<User> userManager, SelectListService selectListService,
            AccountService accountService)
        {
            _userManager = userManager;
            _accountService = accountService;
            _selectListService = selectListService;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _accountService.GetAllUsers();

            return View(users);
        }

        //Create new user => add passwordGenerator
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.roles = _selectListService.GetRoleSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserModel model, string[] Roles)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateUserAsync(model, Roles);

                if (result.Succeeded)
                {
                    var userId = await _accountService.SearchIdByUserGmail(model.Email);
                    return RedirectToAction("ListUsers");
                }

                _accountService.ErrorWriter(result.Errors, ModelState);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _accountService.GetAllRoles();

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            var model = await _accountService.GetRoleForEdit(Id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string Id)
        {
            ViewBag.roleId = Id;

            var model = await _accountService.GetUsersInRoleAsync(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<RoleForUserModel> model, string roleId)
        {
            await _accountService.UpdateUsersInRoleAsync(model, User, roleId);

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string Id)
        {
            var model = await _accountService.GetUserForEditAsync(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.UpdateUserAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                _accountService.ErrorWriter(result.Errors, ModelState);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string Id)
        {
            ViewBag.userId = Id;

            var model = await _accountService.GetRolesInUserAsync(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserForRoleModel> model, string userId)
        {
            await _accountService.UpdateRolesInUserAsync(model, userId);

            return RedirectToAction("EditUser", new { Id = userId });
        }

        public async Task<IActionResult> ChangePassword(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var model = new ChangePasswordModel() { UserId = user.Id, Email = user.Email };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

                if (!string.IsNullOrEmpty(model.Password))
                {
                    var result = await _accountService.ChangePassword(user, model.Password);
                    if (result.Succeeded)
                        return RedirectToAction("EditUser", new { Id = user.Id });
                }
                else
                    ModelState.AddModelError("", "Password cannot be empty");


            }

            return View(model);
        }

        [HttpGet]
        public string GeneratePassword()
        {
            var password = _accountService.PasswordGenerator();

            return password;
        }
    }
}
