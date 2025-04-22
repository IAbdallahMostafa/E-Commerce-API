using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepositry
{
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort);
    Task<Product?> GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    Task<bool> ProductExist(int id);
    Task<bool> SaveChangesAsync();

    Task<IReadOnlyList<string>> GetBrands();
    Task<IReadOnlyList<string>> GetTypes();

}
