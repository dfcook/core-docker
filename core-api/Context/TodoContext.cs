using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using core_api.Model;

namespace core_api.Context
{
  public class TodoContext : DbContext
  {
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
      this.Database.EnsureCreated();
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Todo>(entity =>
      {
        entity.Property(e => e.Id).IsRequired();
        entity.Property(e => e.Text).IsRequired();

        entity.HasKey(e => e.Id);

        entity.HasData(
          new Todo { Id = 1, Text = "Foo" },
          new Todo { Id = 2, Text = "Bar" }
        );
      });
    }
  }
}