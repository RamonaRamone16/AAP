using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.EntitiesConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.Comments)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Theme)
                .WithMany(y => y.Comments)
                .HasForeignKey(x => x.ThemeId);
        }
    }
}
