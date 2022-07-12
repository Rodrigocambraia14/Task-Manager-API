using LawTech.Context.Default.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Context.Default.Mappings
{
    public class UserLoginMapping : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.ToTable("UserLogin");

            builder.Property(e => e.Token)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(e => e.ExpirationDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.CreatedDate)
                  .HasColumnType("datetime")
                  .IsRequired();
        }
    }
}
