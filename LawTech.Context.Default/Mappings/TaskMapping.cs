using LawTech.CrossCutting.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = LawTech.CrossCutting.Enums.TaskStatus;

namespace LawTech.Context.Default.Mappings
{
    public class TaskMapping : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasValueGenerator<GuidValueGenerator>();

            builder.Property(e => e.UserId)
                   .IsRequired();

            builder.Property(e => e.Name)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Description)
                  .HasColumnType("nvarchar")
                  .HasMaxLength(200);

            builder.Property(e => e.CreatedDate)
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(e => e.UpdatedDate)
                   .HasColumnType("datetime");

            builder.Property(e => e.Status)
                  .HasMaxLength(20)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasConversion(
                      v => v.ToString(),
                      v => (TaskStatus)Enum.Parse(typeof(TaskStatus), v));

            builder.Property(e => e.Priority)
                  .HasMaxLength(20)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasConversion(
                      v => v.ToString(),
                      v => (TaskPriority)Enum.Parse(typeof(TaskPriority), v));

            builder.HasOne(e => e.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(e => e.CreatedBy);

            builder.HasOne(e => e.UpdatedByUser)
                   .WithMany()
                   .HasForeignKey(e => e.UpdatedBy);

            builder.HasOne(e => e.User)
                   .WithMany(e => e.Tasks)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
