using Bogus;
using Services.Interfaces;

namespace Services.Bogus
{
    public class BogusService<T> : IService<T> where T : class
    {

        protected ICollection<T> Entities { get; }

        public BogusService(Faker<T> faker) { 
        
            Entities = faker.Generate(100);

        }

        public IEnumerable<T> ReadAll()
        {
            return[.. Entities];
        }

        public bool Delete(T entity)
        {
            return Entities.Remove(entity);
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public bool Replace(T oldEntity, T newEntity)
        {
            if (Entities.Remove(oldEntity))
            {
                Entities.Add(newEntity);
                return true;
            }
            return false;
        }
    }
}
