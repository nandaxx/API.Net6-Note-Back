using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraData.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb() { }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);
        }
    }
}
