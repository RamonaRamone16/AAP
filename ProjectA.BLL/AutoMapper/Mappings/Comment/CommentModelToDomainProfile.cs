using AutoMapper;
using ProjectA.Models.Models.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.BLL.AutoMapper.Mappings.Comment
{
    class CommentModelToDomainProfile : Profile
    {
        public CommentModelToDomainProfile()
        {
            CommentModelToCommentMappingConfig();
        }

        private void CommentModelToCommentMappingConfig()
        {
            CreateMap<CommentModel, DAL.Entities.Comment>();
        }
    }
}
