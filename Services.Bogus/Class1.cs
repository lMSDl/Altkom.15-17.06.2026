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
    }
}
