using AutoMapper;
using ProjectA.Models.Models.Theme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Theme
{
    public class ThemeCreateModelToDomainProfile : Profile
    {
        public ThemeCreateModelToDomainProfile()
        {
            ThemeCreateModelToThemerMappingConfig();
        }

        private void ThemeCreateModelToThemerMappingConfig()
        {
            CreateMap<ThemeCreateModel, DAL.Entities.Theme>();
        }
    }
}
