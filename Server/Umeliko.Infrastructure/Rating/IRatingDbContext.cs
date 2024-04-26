namespace Umeliko.Infrastructure.Rating;

using Common.Persistence;
using Domain.Rating.Models.Comments;
using Domain.Rating.Models.Votes;
using Microsoft.EntityFrameworkCore;

internal interface IRatingDbContext : IDbContext
{
    DbSet<Vote> Votes { get; }

    DbSet<Comment> Comments { get; }
}
