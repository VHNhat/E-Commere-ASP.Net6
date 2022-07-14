using E_Commerce.Models;

namespace E_Commerce.Generic
{
    public interface IGenericService<T> where T : AbstractModel
    {
        List<T> GetAll();
        T Get(long id);
        int Add(T entity);
        int Update(T entity);
        int Delete(long id);
    }
}
