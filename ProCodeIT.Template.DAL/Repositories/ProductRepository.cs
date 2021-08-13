using Microsoft.EntityFrameworkCore;
using ProCodeIT.Template.DAL.Infra.Repositories;
using ProCodeIT.Template.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProCodeIT.Template.DAL.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.ProductsQuery
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetAsync(int codigoProduct)
        {
            return await _dbContext.ProductsQuery
                .FirstOrDefaultAsync(x => x.Id == codigoProduct);
        }

        public async Task<Product> InsertAsync(Product model)
        {
            var query = await _dbContext.Products.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return query.Entity;
        }

        public async void DeleteAsync(Product model)
        {
            _dbContext.Products.Remove(model);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(Product productDb, Product productNew)
        {
            _dbContext.Entry(productDb).CurrentValues.SetValues(productNew);

            await _dbContext.SaveChangesAsync();

            return productDb;
        }
    }
}
