using GP.Data.Infrastructure;
using GP.Domain;
using GP.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GP.Service
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
        public void Add(Product product, string categoryName)
        {
            var categoryRepository = UnitOfWork.GetRepository<Category>();

            var category = categoryRepository.Get(e => e.Name == categoryName);

            if (category == null)
            {
                category = new Category { Name = categoryName };
                categoryRepository.Add(category);
            }

            product.Category = category;
            base.Add(product);
        }
        public void DeleteOldProducts()
        {
            UnitOfWork.GetRepository<Product>().Delete(e => (DateTime.Now - e.DateProd).TotalDays > 365);
        }
        public IEnumerable<Product> GetMost5Expensive()
        {
            return UnitOfWork.GetRepository<Product>().GetAll().OrderByDescending(e => e.Price).Take(5);
        }
        public IEnumerable<Product> GetProductsForClient(string cin)
        {
            return UnitOfWork.GetRepository<Facture>().GetMany(e => e.ClientFK == cin).Select(e => e.Product);
        }
        public float GetUnavailableProductsPercent()
        {
            var productRepository = UnitOfWork.GetRepository<Product>();
            var productsCount = productRepository.GetAll().Count();

            return productsCount == 0 ? -1 : (productRepository.GetMany(e => e.Quantity == 0).Count() / (float)productsCount) * 100;
        }
    }
}
