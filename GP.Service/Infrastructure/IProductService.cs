using GP.Domain;
using System.Collections.Generic;

namespace GP.Service.Infrastructure
{
    public interface IProductService : IService<Product>
    {
        void Add(Product product, string categoryName);
        IEnumerable<Product> GetMost5Expensive();
        float GetUnavailableProductsPercent();
        IEnumerable<Product> GetProductsForClient(string cin);
        void DeleteOldProducts();
    }
}
