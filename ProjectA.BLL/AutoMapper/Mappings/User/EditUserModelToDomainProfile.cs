using AutoMapper;
using ProjectA.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.User
{
    public class EditUserModelToDomainProfile : Profile
    {
        public EditUserModelToDomainProfile()
        {
            EditUserModelToUserMappingConfig();
        }

        private void EditUserModelToUserMappingConfig()
        {
            CreateMap<EditUserModel, DAL.Entities.User>();
        }
    }
}
