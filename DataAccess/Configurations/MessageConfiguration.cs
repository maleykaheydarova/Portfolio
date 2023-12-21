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
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x=> x.Email).HasMaxLength(50); 
            builder.Property(x=> x.Messages).HasMaxLength(200);
            builder.HasIndex(x => x.Name)
                   .HasDatabaseName("idx_Message_Name");
        }
    }
}
