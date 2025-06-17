using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;
using MongoDbWithEntity.MongoDataBase.Entity;
using MongoDB.EntityFrameworkCore.Extensions;
namespace MongoDbWithEntity.MongoDataBase
{
    public class developDbContext :DbContext
    {
        public DbSet<User> Users { get; init; }
        public developDbContext(DbContextOptions options)
        : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToCollection("users");
        }
    }
}
