using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Domain
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<ICollection<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }


}
