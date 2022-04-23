using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectA.Models.Models.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Role
{
    public class UserForRoleModelToDomainProfile : Profile
    {
        public UserForRoleModelToDomainProfile()
        {
            RoleToUserForRoleModelMappingConfig();
        }
        private void RoleToUserForRoleModelMappingConfig()
        {
            CreateMap<IdentityRole, UserForRoleModel>()
                .ForMember(target => target.RoleId,
                    src => src.MapFrom(r => r.Id))
                .ForMember(target => target.RoleName,
                    src => src.MapFrom(r => r.Name));
        }
    }
}
