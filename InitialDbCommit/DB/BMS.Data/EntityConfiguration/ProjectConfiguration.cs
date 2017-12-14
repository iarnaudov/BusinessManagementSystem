﻿namespace BMS.Data.EntityConfiguration
{
    using BMS.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Name);

            builder.Property(e => e.Name)
                .IsRequired()
                .IsUnicode();

            builder.Property(e => e.Date)
                .HasColumnType("DATE");

            builder.Property(e => e.ContractId)
                .IsRequired(false);

            builder.Property(e => e.InquiryId)
                .IsRequired(false);

            builder.Property(e => e.EmployeeId)
                .IsRequired(false);

            builder.HasOne(e => e.Inquiry)
                .WithOne(i => i.Project)
                .HasForeignKey<Project>(e => e.InquiryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Offer)
                .WithOne(o => o.Project)
                .HasForeignKey<Project>(e => e.OfferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Contract)
                .WithOne(c => c.Project)
                .HasForeignKey<Project>(e => e.ContractId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Projects)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
