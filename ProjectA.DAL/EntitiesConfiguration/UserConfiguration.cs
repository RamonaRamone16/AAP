using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Themes)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserId);

            builder.HasMany(x => x.Comments)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.UserId);
        }
    }
}
