using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepositry
{
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<Product?> GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    void ProductExist(int id);
}
