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
    public class AdController : Controller
    {
        private readonly AdService _adService;
        private readonly UserManager<User> _userManager;

        public AdController(AdService adService, UserManager<User> userManager)
        {
            _adService = adService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var records = _adService.GetAll();
                return PartialView("_AllAds", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNew(Ad ad)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                await _adService.Create(ad, user.Id);
                var records = _adService.GetAll();
                return PartialView("_AllAds", records);
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
