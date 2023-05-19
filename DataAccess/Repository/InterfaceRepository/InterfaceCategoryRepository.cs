using Bulky.Models;

namespace Bulky.DataAccess.Repository.InterfaceRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
