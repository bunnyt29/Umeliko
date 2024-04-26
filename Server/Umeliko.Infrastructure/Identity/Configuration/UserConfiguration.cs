namespace Umeliko.Infrastructure.Identity.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Creator)
            .WithOne()
            .HasForeignKey<User>("CreatorId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}
