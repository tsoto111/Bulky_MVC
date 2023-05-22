using Bulky.Models;

namespace Bulky.DataAccess.Repository.InterfaceRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
