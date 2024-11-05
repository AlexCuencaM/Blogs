using Blogs.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Blogs.Models;
public class BlogContext: DbContext
{
    public BlogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Users> Users { get; init; }
    public static BlogContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<BlogContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options
            );
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Users>().ToCollection("users");
    }
}
