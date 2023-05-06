using System;
using hackatonBackend.ProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackatonBackend.ProjectData.Configuration
{
	class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasKey(c => c.Id);
        }
    }
}

