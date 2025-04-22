using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepositry(StoreDBContext context) : IProductRepositry
{
    public void AddProduct(Product product)
    {
        context.Products.AddAsync(product);
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
     {
        return await context.Products.ToListAsync();
    }

    public async Task<bool> ProductExist(int id)
    {
          return await context.Products.AnyAsync(e => e.Id == id);  
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }

    public async Task<bool> SaveChangesAsync() {
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<string>> GetBrands()
    {
        return await context.Products.Select(e => e.Brand).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetTypes()
    {
        return await context.Products.Select(e => e.Type).Distinct().ToListAsync();
    }
}
