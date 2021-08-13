using AutoMapper;
using ProCodeIT.Template.BLL.Infra.Services;
using ProCodeIT.Template.DAL.Infra.UnitsOfWork;
using ProCodeIT.Template.Models.Dummies;
using ProCodeIT.Template.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProCodeIT.Template.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductUoW _productUoW;
        private readonly IMapper _mapper;

        public ProductService(IProductUoW productUoW, IMapper mapper)
        {
            _productUoW = productUoW;
            _mapper = mapper;
        }

        public void Delete(Product product)
        {
            _productUoW.ProductRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var list = await _productUoW.ProductRepository.GetAllAsync();

            return list;
        }

        public async Task<Product> GetAsync(int codigoProduct)
        {
            var result = await _productUoW.ProductRepository.GetAsync(codigoProduct);

            return result;
        }

        public async Task<Product> InsertAsync(ProductDummy product)
        {
            var result = await _productUoW.ProductRepository.InsertAsync(_mapper.Map<Product>(product));

            return result;
        }

        public async Task<Product> UpdateAsync(Product productDb, ProductDummy productNew)
        {
            var result = await _productUoW.ProductRepository.UpdateAsync(productDb, _mapper.Map<Product>(productNew));

            return result;
        }
    }
}
