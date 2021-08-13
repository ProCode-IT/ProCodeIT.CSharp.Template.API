using ProCodeIT.Template.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProCodeIT.Template.DAL.Infra.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int codigoProduct);
        Task<Product> InsertAsync(Product product);
        Task<Product> UpdateAsync(Product productDb, Product productNew);
        void DeleteAsync(Product model);
    }
}
