using ProCodeIT.Template.DAL.Infra.Repositories;

namespace ProCodeIT.Template.DAL.Infra.UnitsOfWork
{
    public interface IProductUoW
    {
        IProductRepository ProductRepository { get; }
    }
}
