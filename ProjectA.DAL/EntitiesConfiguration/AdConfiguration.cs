using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.EntitiesConfiguration
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.Ads)
                .HasForeignKey(x => x.UserId);
        }
    }
}
