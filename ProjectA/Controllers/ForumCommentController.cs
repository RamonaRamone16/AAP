using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectA.BLL.Services;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models.Comment;
using ProjectA.Models.Models.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class ForumCommentController : Controller
    {
        private readonly CommentService _commentService;
        private readonly UserManager<User> _userManager;
        private readonly ThemeService _themeService;

        public ForumCommentController(CommentService commentService, UserManager<User> userManager,
            ThemeService themeService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _themeService = themeService;
        }

        public IActionResult Index(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    ViewBag.BadRequestMessage = "Theme Id is Null";
                    return View("BadRequest");
                }

                ThemeModel theme = _themeService.GetTheme(id.Value);

                return View(theme);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet]
        public IActionResult GetAllComments(int themeId)
        {
            try
            {
                List<CommentModel> records = _commentService.SearchComments(themeId);
                return PartialView("_AllRecords", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNewComment(CommentModel record)
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                await _commentService.Create(record, user.Id);
                var records = _commentService.SearchComments(record.ThemeId);
                return PartialView("_AllRecords", records);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Like(int? recordId)
        {
            try
            {
                if (!recordId.HasValue)
                {
                    ViewBag.BadRequestMessage = "Record Id is Null";
                    return View("BadRequest");
                }

                int likes = await _commentService.LikeComment(recordId.Value);
                return Ok(likes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(int? recordId)
        {
            try
            {
                if (!recordId.HasValue)
                {
                    ViewBag.BadRequestMessage = "Record Id is Null";
                    return View("BadRequest");
                }

                int dislikes = await _commentService.DislikeComment(recordId.Value);
                return Ok(dislikes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
