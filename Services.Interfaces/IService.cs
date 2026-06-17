using Microsoft.VisualBasic.FileIO;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> ReadAll();
        bool Delete(T entity);
    }
}
