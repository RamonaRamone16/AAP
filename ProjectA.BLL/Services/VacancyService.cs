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
    public class VacancyService : BaseService
    {
        public VacancyService(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public List<Vacancy> GetAll()
        {
            var records = _context.Vacancies.Include(x => x.User).ToList();
            return _mapper.Map<List<Vacancy>>(records);
        }

        public async Task Create(Vacancy ad, string userId)
        {
            ad.UserId = userId;
            await _context.AddAsync(ad);
        }
    }
}
