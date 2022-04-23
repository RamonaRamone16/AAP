using AutoMapper;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.User
{
    class RoleForUserModelToDomainProfile : Profile
    {
        public RoleForUserModelToDomainProfile()
        {
            RoleForUserToUserMappingConfig();
        }

        private void RoleForUserToUserMappingConfig()
        {
            CreateMap<RoleForUserModel, DAL.Entities.User>();
        }
    }
}
