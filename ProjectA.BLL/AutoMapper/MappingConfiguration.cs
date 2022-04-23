using AutoMapper;
using ProjectA.BLL.AutoMapper.Mappings.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper
{
    public class MappingConfiguration
    {
        public MapperConfiguration RefisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateUserModelToDomainProfile());
                cfg.AddProfile(new DomainToEditUserModelProfile());
                cfg.AddProfile(new DomainToRoleForUserModelProfile());
                cfg.AddProfile(new EditUserModelToDomainProfile());
                cfg.AddProfile(new RoleForUserModelToDomainProfile());
            });
        }
    }
}
