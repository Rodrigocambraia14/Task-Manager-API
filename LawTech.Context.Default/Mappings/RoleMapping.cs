using LawTech.Context.Default.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawTech.Context.Default.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100);

            builder.Property(e => e.Description)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(e => e.CreatedDate)
                  .HasColumnType("datetime");

            builder.HasMany(e => e.UserRoles)
                   .WithOne(e => e.Role)
                   .HasForeignKey(e => e.RoleId);
        }
    }
}
