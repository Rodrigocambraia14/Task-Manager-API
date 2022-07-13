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
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.Email)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.ImageProfile)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(500);

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(e => e.UserName)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.HasMany(e => e.UserRoles)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId);

            builder.HasMany(e => e.UserLogins)
                   .WithOne()
                   .HasForeignKey(e => e.UserId);

            builder.HasMany(e => e.Tasks)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId);

        }
    }
}
