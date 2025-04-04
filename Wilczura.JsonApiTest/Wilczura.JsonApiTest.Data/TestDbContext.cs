using Microsoft.EntityFrameworkCore;
using Wilczura.JsonApiTest.Data.Entities;

namespace Wilczura.JsonApiTest.Data;

public class TestDbContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonDetailsView> PersonDetails { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasPostgresExtension("citext");
        modelBuilder
            .Entity<PersonDetailsView>()
            .ToView("persons_view")
            .HasKey(t => t.Id);
    }
}
