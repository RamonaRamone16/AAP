using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.Services
{
    public class BaseService
    {
        protected readonly ApplicationDBContext _context;
        protected readonly IMapper _mapper;
        protected readonly UserManager<User> _userManager;
        public BaseService(ApplicationDBContext context, IMapper mapper, UserManager<User> userManager = null)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
    }
}
