using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models;
using ProjectA.Models.Models.Role;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BLL.Services
{
    public class AccountService : BaseService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ApplicationDBContext context, IPasswordHasher<User> passwordHasher, SignInManager<User> signInManager) : base(context, mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _signInManager = signInManager;
        }


        public IQueryable<User> GetAllUsers()
        {
            return _userManager.Users;
        }


        public async Task<IdentityResult> CreateUserAsync(CreateUserModel model, string[] Roles)
        {
            User user = _mapper.Map<User>(model);
            var IdentityResult = await _userManager.CreateAsync(user, model.Password);
            if (Roles.Length > 0)
                await _userManager.AddToRolesAsync(user, Roles);
            return IdentityResult;
        }


        public IQueryable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }


        public async Task<EditRoleModel> GetRoleForEdit(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            var model = new EditRoleModel { Id = role.Id, RoleName = role.Name };

            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return model;
        }


        public async Task<List<RoleForUserModel>> GetUsersInRoleAsync(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);

            var model = new List<RoleForUserModel>();

            foreach (var user in _userManager.Users.ToList())
            {
                var userRoleViewModel = _mapper.Map<RoleForUserModel>(user);

                userRoleViewModel.IsSelected = await _userManager.IsInRoleAsync(user, role.Name);

                model.Add(userRoleViewModel);
            }

            return model;
        }


        public async Task UpdateUsersInRoleAsync(List<RoleForUserModel> model, ClaimsPrincipal User, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);


                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }

                if (_userManager.GetUserId(User) == user.Id)
                    await _signInManager.RefreshSignInAsync(user);

            }

        }


        public async Task<EditUserModel> GetUserForEditAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var userRoles = await _userManager.GetRolesAsync(user);

            var editUser = _mapper.Map<EditUserModel>(user);
            editUser.Roles = userRoles;

            return editUser;
        }


        public async Task<IdentityResult> UpdateUserAsync(EditUserModel model)
        {

            var user = _mapper.Map<User>(model);
            return await _userManager.UpdateAsync(user);
        }


        public async Task<List<UserForRoleModel>> GetRolesInUserAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var model = new List<UserForRoleModel>();

            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = _mapper.Map<UserForRoleModel>(role);

                userRolesViewModel.IsSelected = await _userManager.IsInRoleAsync(user, role.Name);

                model.Add(userRolesViewModel);
            }

            return model;
        }


        public async Task UpdateRolesInUserAsync(List<UserForRoleModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);

            await _userManager
                .AddToRolesAsync(user, model.Where(x => x.IsSelected)
                    .Select(y => y.RoleName));
            await _signInManager.RefreshSignInAsync(user);
        }




        public async Task<IdentityResult> ChangePassword(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            return await _userManager.UpdateAsync(user);
        }


        public string PasswordGenerator()
        {
            var options = _userManager.Options.Password;

            int length = options.RequiredLength;

            bool nonAlphanumeric = options.RequireNonAlphanumeric;
            bool digit = options.RequireDigit;
            bool lowercase = options.RequireLowercase;
            bool uppercase = options.RequireUppercase;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }


        public void ErrorWriter(IEnumerable<IdentityError> resultErrors, ModelStateDictionary modelState)
        {
            foreach (var error in resultErrors)
            {
                modelState.AddModelError("", error.Description);
            }
        }

        public async Task<string> SearchIdByUserGmail(string email)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == email);
            return user.Id;
        }
    }
}
