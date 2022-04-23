using AutoMapper;
using ProjectA.Models.Models.Theme;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Theme
{
    class DomainProfileToThemeModel : Profile
    {
        public DomainProfileToThemeModel()
        {
            ThemeToThemeModelMappingConfig();
        }

        private void ThemeToThemeModelMappingConfig()
        {
            CreateMap<DAL.Entities.Theme, ThemeModel>()
                .ForMember(target => target.UserName,
                    src => src.MapFrom(u => $"{u.User.Name} {u.User.Surname}"))
                .ForMember(target => target.CommentsCount,
                    src => src.MapFrom(u => u.Comments.Count));
        }
    }
}
