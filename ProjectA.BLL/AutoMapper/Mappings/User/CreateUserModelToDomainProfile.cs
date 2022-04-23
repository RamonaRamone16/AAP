using AutoMapper;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.User
{
    public class CreateUserModelToDomainProfile : Profile
    {
        public CreateUserModelToDomainProfile()
        {
            CreateUserModelToUserMappingConfig();
        }

        private void CreateUserModelToUserMappingConfig()
        {
            CreateMap<CreateUserModel, DAL.Entities.User>()
                .ForMember(target => target.UserName,
                    src => src.MapFrom(u => u.Email));
        }
    }
}
