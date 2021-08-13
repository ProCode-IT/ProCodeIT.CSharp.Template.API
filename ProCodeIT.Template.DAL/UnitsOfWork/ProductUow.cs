using ProCodeIT.Template.DAL.Infra.Repositories;
using ProCodeIT.Template.DAL.Infra.UnitsOfWork;

namespace ProCodeIT.Template.DAL.UnitsOfWork
{
    public class ProductUow : IProductUoW
    {
        public ProductUow(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }

    }
}
