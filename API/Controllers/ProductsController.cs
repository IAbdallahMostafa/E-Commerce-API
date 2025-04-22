using System;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ProductsController (IProductRepositry products) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        return Ok(await products.GetProductsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await products.GetProductById(id);
        return product == null ? NotFound() : product;  
    }
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        products.AddProduct(product);
        if (await products.SaveChangesAsync())
            return CreatedAtAction("GetProduct", new {product.Id}, product);
        return BadRequest("Problem While Creating Product");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
    {
        if (!await ProductExist(id) || id != product.Id)
            return BadRequest("Cann't Update This Product!");
        
        products.UpdateProduct(product);

        if (await products.SaveChangesAsync())
            return NoContent();

        return BadRequest("Problem While Updating Product");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await products.GetProductById(id);
        
        if (product is null) return NotFound();

        products.DeleteProduct(product);
        
        if (await products.SaveChangesAsync())
            return NoContent();
        
        return BadRequest("Problem While Deleting Product");
    }

    private async Task<bool> ProductExist(int id)
    {
        return await products.ProductExist(id);
    }
}
