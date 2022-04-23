using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectA.DAL;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.BLL.Services
{
    public class AdService : BaseService
    {
        public AdService(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public List<Ad> GetAll()
        {
            var records = _context.Ads.Include(x => x.User).ToList();
            return _mapper.Map<List<Ad>>(records);
        }

        public async Task Create(Ad ad, string userId)
        {
            ad.UserId = userId;
            await _context.AddAsync(ad);
        }
    }
}
