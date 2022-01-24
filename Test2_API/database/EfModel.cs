using Microsoft.EntityFrameworkCore;
using SchooApi.model;
using Test2_API.model;
using Test2_API.model.Auth;

namespace Test2_API.database
{
    public class EfModel: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<School>();
        }

        public EfModel(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<School> schools { get; set; }

        public virtual DbSet<User> user { get; set; }

        public virtual DbSet<Subject> subjects { get; set; }

        public virtual DbSet<Student> students { get; set; }
    }
}
