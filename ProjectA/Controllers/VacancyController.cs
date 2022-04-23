using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectA.BLL.Services;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class VacancyController : Controller
    {
        private readonly VacancyService _vacancyService;
        private readonly UserManager<User> _userManager;

        public VacancyController(VacancyService vacancyService, UserManager<User> userManager)
        {
            _vacancyService = vacancyService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var records = _vacancyService.GetAll();
                return PartialView("_AllVacancies", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNew(Vacancy vacancy)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                await _vacancyService.Create(vacancy, user.Id);
                var records = _vacancyService.GetAll();
                return PartialView("_AllVacancies", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
    }
}
