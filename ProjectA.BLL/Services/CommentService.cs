using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BLL.Services
{
    public class CommentService : BaseService
    {
        public CommentService(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<int> LikeComment(int recordId)
        {
            Comment comment = _context.Comments.FirstOrDefault(x=> x.Id == recordId);
            comment.Likes++;
            await _context.UpdateAsync(comment);
            return comment.Likes;
        }

        public async Task<int> DislikeComment(int recordId)
        {
            Comment comment = _context.Comments.FirstOrDefault(x => x.Id == recordId);
            comment.Dislikes++;
            await _context.UpdateAsync(comment);
            return comment.Dislikes;
        }


        public List<CommentModel> SearchComments(int themeId)
        {
            List<Comment> records = _context.Comments.Include(x => x.User).Where(x => x.ThemeId == themeId).ToList();
            return _mapper.Map<List<CommentModel>>(records);
        }

        public async Task Create(CommentModel recordModel, string userId)
        {
            Comment comment = _mapper.Map<Comment>(recordModel);
            comment.UserId = userId;
            comment.CreatedUtc = DateTime.Now;
            await _context.AddAsync(comment);
        }
    }
}
