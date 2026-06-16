using Models;

namespace Services.Bogus.Fakers
{
    public class ProductFaker : BaseFaker<Product>
    {
        public ProductFaker()
        {

            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Price, f => f.Random.Float(1, 1000));
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            //RuleFor(p => p.ExpirationDate, f => f.Date.Future());

        }
    }
}
