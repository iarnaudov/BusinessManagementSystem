﻿namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjectConfiguration:IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasOne(c => c.Contragent).WithMany(p => p.Projects).HasForeignKey(c => c.ContragentId);
            builder.Property(n => n.Name).IsUnicode();

        }
    }
}
