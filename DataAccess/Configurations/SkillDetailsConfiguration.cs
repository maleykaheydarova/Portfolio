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
    internal class SkillDetailsConfiguration : IEntityTypeConfiguration<SkillDetails>
    {
        public void Configure(EntityTypeBuilder<SkillDetails> builder)
        {
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
            builder.HasIndex(x => new { x.SkillID, x.Deleted })
                  .IsUnique()
                  .HasDatabaseName("idx_SkillID_Deleted");
        }
    }
}
