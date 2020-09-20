using System.Collections.Generic;
using System.Threading.Tasks;
using FooOffer.Core.Entities;

namespace FooOffer.BusinessLogic.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        
        // Task<T> Add(T entity);
        // Task<T> Update(T entity);
        // Task<T> Delete(int id);
    }
}