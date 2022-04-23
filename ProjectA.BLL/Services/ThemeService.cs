using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using ProjectA.Models.Models.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BLL.Services
{
    public class ThemeService : BaseService
    {
        public ThemeService(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public List<ThemeModel> GetAllThemes()
        {
            var themes = _context.Themes.Include(x => x.User).Include(x => x.Comments);

            return _mapper.Map<List<ThemeModel>>(themes.ToList());
        }

        public async Task CreateTheme(ThemeCreateModel themeCreateModel, string userId)
        {
            var theme = _mapper.Map<Theme>(themeCreateModel);
            theme.UserId = userId;
            theme.CreatedUtc = DateTime.Now;
            await _context.AddAsync(theme);
        }

        public ThemeModel GetTheme(int id)
        {
            Theme themes = _context.Themes.Include(x => x.User).FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ThemeModel>(themes);
        }
    }
}
