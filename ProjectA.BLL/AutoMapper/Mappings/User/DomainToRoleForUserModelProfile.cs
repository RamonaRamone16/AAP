using AutoMapper;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.User
{
    public class DomainToRoleForUserModelProfile : Profile
    {
        public DomainToRoleForUserModelProfile()
        {
            UserToRoleForUserModelConfig();
        }

        private void UserToRoleForUserModelConfig()
        {
            CreateMap<DAL.Entities.User, RoleForUserModel>()
                .ForMember(target => target.UserId,
                    src => src.MapFrom(u => u.Id));
        }
    }
}
