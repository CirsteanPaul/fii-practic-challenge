using System;
using hackatonBackend.ProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackatonBackend.ProjectData.Configuration
{
	class GameConfiguration : IEntityTypeConfiguration<Game>
	{   
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(c => c.Id);
        }
       
    }
}

