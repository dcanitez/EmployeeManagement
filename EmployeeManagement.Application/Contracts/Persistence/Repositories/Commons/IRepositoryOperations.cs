using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Contracts.Persistence.Repositories.Commons
{
    public interface IRepositoryOperations<TEntity, T>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(T id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity, T id);
        Task<TEntity> Delete(T id);
    }
}
