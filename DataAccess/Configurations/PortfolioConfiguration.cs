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
    internal class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
           builder.Property(x=>x.Title).HasMaxLength(50);
            builder.HasIndex(x => new { x.CategoryID, x.Deleted})
                   .HasDatabaseName("idx_Portfolio_CategoryID_Deleted");
           

        }
    }
}
