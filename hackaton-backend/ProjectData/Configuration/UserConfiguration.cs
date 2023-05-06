using hackatonBackend.ProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackatonBackend.ProjectData.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.HasOne(x => x.Recruit)
                .WithOne(t => t.User)
                .HasForeignKey<Recruit>(t => t.UserId);

            builder.HasOne(x => x.Company)
               .WithOne(t => t.User)
               .HasForeignKey<Company>(t => t.UserId);
        }
    }
}
