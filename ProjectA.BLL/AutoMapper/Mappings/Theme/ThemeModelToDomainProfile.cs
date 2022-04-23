using AutoMapper;
using ProjectA.Models.Models.Theme;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Theme
{
    public class ThemeModelToDomainProfile : Profile
    {
        public ThemeModelToDomainProfile()
        {
            ThemeModelToThemerMappingConfig();
        }

        private void ThemeModelToThemerMappingConfig()
        {
            CreateMap<ThemeModel, DAL.Entities.Theme>();
        }
    }
}
