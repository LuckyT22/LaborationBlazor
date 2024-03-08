using LaborationBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborationBlazor.Data
{
    public class DataAccess
    {
        private readonly ProductContext _productContext;
    
        public DataAccess(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            await Task.Delay(500);
            var productsTask = _productContext.Products.ToListAsync();
            //Gör annat medan vi väntar på databasen (som är långsam)
            var products = await productsTask;
            return products;
        }
                
        public async Task AddProduct(Product product)
        {
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            var result = await _productContext.Products.FindAsync(id);
            return result;
        }
        public async Task UpdateProduct(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
        }
    }
}
