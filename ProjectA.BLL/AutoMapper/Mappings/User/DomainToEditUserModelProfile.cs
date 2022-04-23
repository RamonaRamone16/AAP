using AutoMapper;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.User
{
    public class DomainToEditUserModelProfile : Profile
    {
        public DomainToEditUserModelProfile()
        {
            UserToEditUserModelMappingConfig();
        }

        private void UserToEditUserModelMappingConfig()
        {
            CreateMap<DAL.Entities.User, EditUserModel>();
        }
    }
}
