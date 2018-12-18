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
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Todo>(entity =>
      {
        entity.Property(e => e.Id).IsRequired();
        entity.Property(e => e.Text).IsRequired();
        entity.Property(e => e.UserId).IsRequired().HasDefaultValue("baz");

        entity.HasKey(e => e.Id);

        entity.HasData(
          new Todo { Id = 3, Text = "Baz", UserId = "baz" }
        );
      });
    }
  }
}