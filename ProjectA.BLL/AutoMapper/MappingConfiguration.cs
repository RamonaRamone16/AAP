using AutoMapper;
using ProjectA.BLL.AutoMapper.Mappings.Comment;
using ProjectA.BLL.AutoMapper.Mappings.Role;
using ProjectA.BLL.AutoMapper.Mappings.Theme;
using ProjectA.BLL.AutoMapper.Mappings.User;

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
                cfg.AddProfile(new UserForRoleModelToDomainProfile());
                cfg.AddProfile(new DomainProfileToThemeModel());
                cfg.AddProfile(new ThemeModelToDomainProfile());
                cfg.AddProfile(new ThemeCreateModelToDomainProfile());
                cfg.AddProfile(new CommentModelToDomainProfile());
                cfg.AddProfile(new DomainProfileToCommentModel());
            });
        }
    }
}
