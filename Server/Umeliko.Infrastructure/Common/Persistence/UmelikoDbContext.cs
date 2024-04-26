namespace Umeliko.Infrastructure.Common.Persistence;

using Domain.Common.Models;
using Domain.Learning.Models.Creators;
using Domain.Learning.Models.Materials;
using Domain.Rating.Models.Comments;
using Domain.Rating.Models.Votes;
using Events;
using Identity;
using Learning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rating;
using System.Reflection;

internal class UmelikoDbContext(
        DbContextOptions<UmelikoDbContext> options,
        IEventDispatcher eventDispatcher)
        : IdentityDbContext<User>(options),
            ILearningDbContext, IRatingDbContext
{
    private readonly Stack<object> savesChangesTracker = new();

    public DbSet<Creator> Creators { get; set; } = default!;

    public DbSet<Follow> Follows { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    public DbSet<Material> Materials { get; set; } = default!;

    public DbSet<Banner> Banners { get; set; } = default!;

    public DbSet<Keyword> Keywords { get; set; } = default!;

    public DbSet<Article> Articles { get; set; } = default!;

    public DbSet<Lesson> Lessons { get; set; } = default!;

    public DbSet<Resource> Resources { get; set; } = default!;

    public DbSet<Course> Courses { get; set; } = default!;

    public DbSet<Section> Sections { get; set; } = default!;

    public DbSet<Item> Items { get; set; } = default!;

    public DbSet<Vote> Votes { get; set; } = default!;

    public DbSet<Comment> Comments { get; set; } = default!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        this.savesChangesTracker.Push(new object());

        var entities = this.ChangeTracker
            .Entries<IEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entities)
        {
            var events = entity.Events.ToArray();

            entity.ClearEvents();

            foreach (var domainEvent in events)
            {
                await eventDispatcher.Dispatch(domainEvent);
            }
        }

        this.savesChangesTracker.Pop();

        if (!this.savesChangesTracker.Any())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        return 0;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var roleId = Guid.NewGuid().ToString();
        builder
            .Entity<IdentityRole>()
            .HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = roleId,
            });

        var adminId = Guid.NewGuid().ToString();
        var admin = new User()
        {
            Id = adminId,
            Email = "umeliko.team@gmail.com",
            NormalizedEmail = "UMELIKO.TEAM@GMAIL.COM",
            EmailConfirmed = true,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
        };

        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_1234");

        builder
            .Entity<User>()
            .HasData(admin);

        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId,
            });

        base.OnModelCreating(builder);
    }
}
