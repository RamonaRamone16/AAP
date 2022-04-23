using AutoMapper;
using ProjectA.Models.Models.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Comment
{
    class DomainProfileToCommentModel : Profile
    {
        public DomainProfileToCommentModel()
        {
            CommentToCommentModelMappingConfig();
        }

        private void CommentToCommentModelMappingConfig()
        {
            CreateMap<DAL.Entities.Comment, CommentModel>()
                .ForMember(target => target.UserName,
                    src => src.MapFrom(u => $"{u.User.Name} {u.User.Surname}"));
        }
    }
}
