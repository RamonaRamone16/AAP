using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.EntitiesConfiguration
{
    public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.Themes)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Comments)
                .WithOne(y => y.Theme)
                .HasForeignKey(y => y.ThemeId);
        }
    }
}
