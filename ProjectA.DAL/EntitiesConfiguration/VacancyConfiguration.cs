using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectA.DAL.EntitiesConfiguration
{

    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.Vacancies)
                .HasForeignKey(x => x.UserId);
        }
    }
}
