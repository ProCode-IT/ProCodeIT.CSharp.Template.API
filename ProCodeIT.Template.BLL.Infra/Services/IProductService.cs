using ProCodeIT.Template.Models.Dummies;
using ProCodeIT.Template.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProCodeIT.Template.BLL.Infra.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int codigoProduct);
        Task<Product> InsertAsync(ProductDummy product);
        Task<Product> UpdateAsync(Product productDb, ProductDummy productNew);
        void Delete(Product product);
    }
}
