using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(x=> x.CompanyName).HasMaxLength(50);
            builder.Property(x=>x.Description).HasMaxLength(500);
            builder.HasIndex(x => new { x.PositionID, x.CompanyName})
                  .IsUnique()
                  .HasDatabaseName("idx_Position_Company_Name");

        }
    }
}
