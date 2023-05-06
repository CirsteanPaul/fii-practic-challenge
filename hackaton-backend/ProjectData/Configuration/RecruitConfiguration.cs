using System;
using hackatonBackend.ProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackatonBackend.ProjectData.Configuration
{
    class RecruitConfiguration : IEntityTypeConfiguration<Recruit>
    {
        public void Configure(EntityTypeBuilder<Recruit> builder)
        {
            builder
                .HasKey(c => c.Id);
        }
    }
}

