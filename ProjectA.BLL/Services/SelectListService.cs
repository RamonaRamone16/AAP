using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BLL.Services
{
    public class SelectListService : BaseService
    {

        protected readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public SelectListService(ApplicationDBContext context, IMapper mapper, RoleManager<IdentityRole> roleManager, UserManager<User> userManager) : base(context, mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

       /* public async Task<SelectList> GetSelectList(string fieldName)
        { 
        
                var entities = await _context.Roles;
                return new SelectList(entities, nameof(IEntity.Id), fieldName); 
        }
*/
        public async Task<SelectList> GetRoleSelectList()
        {
            return new SelectList(_roleManager.Roles, "Name", "Name");
        }
        public async Task<SelectList> GetUserSelectList()
        {
            return new SelectList(_userManager.Users, "Id", "Email");
        }
    }
}
