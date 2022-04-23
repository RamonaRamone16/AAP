using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectA.BLL.Services;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class ForumThemeController : Controller
    {
        private readonly ThemeService _themeService;
        private readonly UserManager<User> _userManager;

        public ForumThemeController(ThemeService themeService, UserManager<User> userManager)
        {
            if (themeService == null)
                throw new ArgumentNullException(nameof(themeService));
            if (userManager == null)
                throw new ArgumentNullException(nameof(userManager));
            _themeService = themeService;
            _userManager = userManager;
        }

        public IActionResult GetAllThemes()
        {
            try
            {
                List<ThemeModel> themes = _themeService.GetAllThemes();
                return PartialView("_AllThemes", themes);
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTheme(ThemeCreateModel theme)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                await _themeService.CreateTheme(theme, user.Id);
                List<ThemeModel> themes = _themeService.GetAllThemes();
                return PartialView("_AllThemes", themes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
