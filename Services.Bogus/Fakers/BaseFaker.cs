using Bogus;

namespace Services.Bogus.Fakers
{
    public class BaseFaker<T> : Faker<T> where T : class
    {
        protected BaseFaker() : base("pl")
        {

        }
    }
}
