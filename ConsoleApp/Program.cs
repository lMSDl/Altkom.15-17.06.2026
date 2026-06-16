

using Models;
using Services.Bogus;
using Services.Bogus.Fakers;
using Services.Interfaces;

IService <Product> service = new BogusService<Product>(new ProductFaker());

foreach (var product in service.ReadAll())
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Description: {product.Description}, Expiration Date: {product.ExpirationDate}");
}