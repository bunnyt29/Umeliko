namespace Umeliko.Infrastructure.Rating.Configuration;

using Domain.Rating.Models.Votes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder
            .HasKey(v => v.Id);

        builder
            .OwnsOne(v => v.VoteType,
                vo =>
                {
                    vo.WithOwner();

                    vo.Property(vt => vt.Value);
                });

        builder.HasIndex(v => new
        {
            v.CreatorId,
            v.MaterialId
        })
            .IsUnique();
    }
}
