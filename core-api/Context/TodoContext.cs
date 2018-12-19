using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using CoreApi.Model;

namespace CoreApi.Context
{
  public class TodoContext : DbContext
  {
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
      Database.EnsureCreated();
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Todo>(entity =>
      {
        entity.Property(e => e.Text).IsRequired();
        entity.Property(e => e.IsCompleted).IsRequired();
        entity.Property(e => e.UserId).IsRequired();

        entity.HasKey(e => e.Id);
      });
    }
  }
}