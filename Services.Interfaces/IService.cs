using Microsoft.VisualBasic.FileIO;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> ReadAll();
        bool Delete(T entity);
        void Add(T entity);
        bool Replace(T oldEntity, T newEntity);
    }
}
