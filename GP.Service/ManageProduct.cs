using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public class ManageProduct
    {
        readonly IList<Product> products;
        public Func<string, IEnumerable<Product>> FindProducts { get; private set; }
        public Action<string> ScanProduct { get; private set; }
        public ManageProduct(IList<Product> products)
        {
            this.products = products;

            //FindProducts = delegate (string c)
            //{
            //    var list = new List<Product>();

            //    foreach (var product in products)
            //    {
            //        if (product.Name != null && product.Name.ToUpper().StartsWith(c.ToUpper()))
            //        {
            //            list.Add(product);
            //        }
            //    }

            //    return list;
            //};

            //ScanProduct = delegate (string categoryName)
            //{
            //    foreach (var product in products)
            //    {
            //        if (product.Category != null && product.Category.Name == categoryName)
            //        {
            //            product.GetDetails();
            //        }
            //    }
            //};

            FindProducts = c =>
            {
                var list = new List<Product>();

                foreach (var product in products)
                {
                    if (product.Name != null && product.Name.ToUpper().StartsWith(c.ToUpper()))
                    {
                        list.Add(product);
                    }
                }

                return list;
            };

            ScanProduct = categoryName =>
            {
                foreach (var product in products)
                {
                    if (product.Category != null && product.Category.Name == categoryName)
                    {
                        product.GetDetails();
                    }
                }
            };
        }
        public IEnumerable<Product> Get5Product(double price)
        {
            return (from product in products
                    where product.Price > price
                    select product).Take(5);
        }
        public IEnumerable<Product> GetProductPrice(double price)
        {
            return (from product in products
                    where product.Price > price
                    select product).Skip(2);
        }
        public double GetAveragePrice()
        {
            return (from product in products
                    select product.Price)
                    .Average();
        }
        public KeyValuePair<string, double> GetMaxPrice()
        {
            var max = (from product in products
                       select product.Price).Max();

            var first = (from product in products
                         where product.Price >= max
                         select new
                         {
                             Name = product.Name,
                             Price = product.Price
                         }).First();

            return new KeyValuePair<string, double>(first.Name, first.Price);

        }
        public int GetCountProduct(string city)
        {
            return (from product in products
                    where product is Chemical && ((Chemical)product).Address != null && ((Chemical)product).Address.City == city
                    select product).Count();
        }
        public IEnumerable<Product> GetChemicalCity()
        {
            return (from product in products
                        where product is Chemical
                        where product is Chemical
                        orderby ((Chemical)product).Address.City descending
                        select product);
        }
        public IEnumerable<IGrouping<string,Chemical>> GetChemicalGroupByCity()
        {
            return from product in products
                        where product is Chemical
                        orderby ((Chemical)product).Address.City descending
                        group (Chemical)product by ((Chemical)product).Address.City;
        }
    }
}
