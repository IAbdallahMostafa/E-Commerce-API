using System;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
