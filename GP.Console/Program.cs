using GP.Domain;
using System;
using s = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GP.Service;
using GP.Data;
using System.Data.Entity.Validation;
using GP.Data.Infrastructure;

namespace GP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TP1();
            //TP2();
            //TP3();
            //TP4();
            TP5();
        }
        static void TP1()
        {
            //var provider = new Provider { Password = "saidani", ConfirmPassword = "saidani"};

            //Provider.SetIsApproved(provider.Password, provider.ConfirmPassword, provider.IsApproved);
            //s.Console.WriteLine($"Password : {provider.Password}, ConfirmPassword : {provider.ConfirmPassword}, IsApproved : {provider.IsApproved}");
            //Provider.SetIsApproved(provider);
            //s.Console.WriteLine($"Password : {provider.Password}, ConfirmPassword : {provider.ConfirmPassword}, IsApproved : {provider.IsApproved}");

            //var provider = new Provider { Password = "sa" };

            var cat1 = new Category { Name = "CAT1" };
            var cat2 = new Category { Name = "CAT2" };
            var cat3 = new Category { Name = "CAT3" };
            var prov1 = new Provider { UserName = "PROV1" };
            var prov2 = new Provider { UserName = "PROV2" };
            var prov3 = new Provider { UserName = "PROV3" };
            var prov4 = new Provider { UserName = "PROV4" };
            var prov5 = new Provider { UserName = "PROV5" };
            var prod1 = new Product { Name = "PROD1", Category = cat1, Providers = new List<Provider> { prov1, prov2, prov3 } };
            var prod2 = new Product { Name = "PROD2", Category = cat1, Providers = new List<Provider> { prov1 } };
            var prod3 = new Product { Name = "PROD3", Category = cat3, Providers = new List<Provider> { prov1 } };
            var prod4 = new Product { Name = "PROD4", Providers = new List<Provider> { prov3, prov4, prov5 } };
            var prod5 = new Product { Name = "PROD5", Category = cat2, Providers = new List<Provider>() };
            var prod6 = new Product { Name = "PROD6", Category = cat3, Providers = new List<Provider> { prov4, prov5 } };

            cat1.Products = new List<Product> { prod1, prod2 };
            cat2.Products = new List<Product> { prod5 };
            cat3.Products = new List<Product> { prod3, prod6 };
            prov1.Products = new List<Product> { prod1, prod2, prod3 };
            prov2.Products = new List<Product> { prod1, prod5 };
            prov3.Products = new List<Product> { prod1 };
            prov4.Products = new List<Product> { prod4, prod6 };
            prov5.Products = new List<Product> { prod4, prod6 };

            s.Console.WriteLine("Détails des providers");
            prov1.GetDetails();
            prov2.GetDetails();
            prov3.GetDetails();

            prov1.GetProducts("DATE", "");

            //Tester les autres méthodes
            //...
            //...
        }
        static void TP2()
        {
            var fruit = new Category { Name = "Fruit" };
            var alimentaire = new Category { Name = "Alimentaire" };

            var acideCitrique = new Chemical
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "ACIDE CITRIQUE",
                Description = "Monohydrate - E330 - USP32",
                Category = alimentaire,
                Price = 90,
                Quantity = 30,
                Address = new Address { City = "Sousse" }
            };
            var cacaoNaturelle = new Chemical
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "POUDRE DE CACAO NATURELLE",
                Description = "10% -12%",
                Category = alimentaire,
                Price = 419,
                Quantity = 80,
                Address = new Address { City = "Sfax" }
            };
            var cacaoAlcalinisee = new Chemical
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "POUDRE DE CACAO ALCALINISÉE",
                Description = "10% -12%",
                Category = alimentaire,
                Price = 60,
                Quantity = 300,
                Address = new Address { City = "Sfax" }
            };
            var dioxyde = new Chemical
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "DIOXYDE DE TITANE",
                Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
                Category = alimentaire,
                Price = 200,
                Quantity = 50,
                Address = new Address { City = "Tunis" }
            };
            var amidon = new Chemical
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "AMIDON DE MAÏS",
                Description = "Amidon de maïs natif",
                Category = alimentaire,
                Price = 70,
                Quantity = 30,
                Address = new Address { City = "Tunis" }
            };
            var blackberry = new Biological
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Blackberry",
                Description = string.Empty,
                Category = fruit,
                Price = 60,
                ProductId = 0,
                Quantity = 0

            };

            var apple = new Biological
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = string.Empty,
                Category = fruit,
                Name = "Apple",
                Price = 100.00,
                ProductId = 0,
                Quantity = 100

            };

            var products = new List<Product> { dioxyde, amidon, cacaoAlcalinisee, blackberry, apple, acideCitrique, cacaoNaturelle };

            var sater = new Provider() { Id = 1, UserName = "SATER" };
            var sudMedical = new Provider() { Id = 2, UserName = "SUDMEDICAL" };
            var palliserSa = new Provider() { Id = 3, UserName = "Palliser SA" };
            var prov4 = new Provider() { Id = 4, UserName = "PROV4" };
            var prov5 = new Provider() { Id = 5, UserName = "PROV5" };
            var providers = new List<Provider> { sater, sudMedical, palliserSa, prov4, prov5 };

            var manageProduct = new ManageProduct(products);
            var manageProvider = new ManageProvider(providers);

            Action<IEnumerable<Product>> showProducts = productsToShow =>
            {
                foreach (var product in productsToShow)
                {
                    product.GetDetails();
                }
            };

            Action<IEnumerable<Provider>> showProviders = providersToShow =>
            {
                foreach (var provider in providersToShow)
                {
                    provider.GetDetails();
                }
            };

            //showProducts(manageProduct.FindProducts("a"));
            //manageProduct.ScanProduct(fruit.Name);
            //showProviders(manageProvider.GetProviderByName("2"));
            //manageProvider.GetFirstProviderByName("SA").GetDetails();
            //manageProvider.GetProviderById(3).GetDetails();
            //showProducts(manageProduct.Get5Product(50));
            //showProducts(manageProduct.GetProductPrice(50));
            //s.Console.WriteLine(manageProduct.GetAveragePrice());

            var maxPrice = manageProduct.GetMaxPrice();
            //s.Console.WriteLine($"{maxPrice.Key} , {maxPrice.Value}");

            //s.Console.WriteLine(manageProduct.GetCountProduct("Tunis"));

            //showProducts(manageProduct.GetChemicalCity());

            /*foreach (var group in manageProduct.GetChemicalGroupByCity())
            {
                s.Console.WriteLine($"City : {group.Key}");

                foreach (var chemical in group)
                {
                    chemical.GetDetails();
                }
            }*/

            /*manageProduct.UpperName(apple);
            s.Console.WriteLine(apple.Name);*/

            //s.Console.WriteLine(manageProduct.InCategory(apple, alimentaire));
        }
        static void TP3()
        {
            using (var context = new GPContext())
            {
                context.Providers.Add(new Provider { DateCreated = DateTime.Now, Password = "mypassword1", ConfirmPassword = "mypassword1", Email = "myemail@gmail.com" });

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var error in exception.EntityValidationErrors)
                    {
                        s.Console.WriteLine($"Validation error in '{error.Entry.Entity}'");

                        foreach (var validationError in error.ValidationErrors)
                        {
                            s.Console.WriteLine($"For property '{validationError.PropertyName}' : {validationError.ErrorMessage}");
                        }

                        s.Console.WriteLine("-----------------");
                    }
                }
            }
        }
        static void TP4()
        {
            using (var unitOfWork = new UnitOfWork(new GPDatabaseFactory()))
            {
                var category = new Category { Name = "CAT" };

                unitOfWork.GetRepository<Category>().Add(category);
                unitOfWork.GetRepository<Product>().Add(new Product { Name = "PROD", Category = category });
                unitOfWork.Commit();
            }
        }
        static void TP5()
        {
            using (var unitOfWork = new UnitOfWork(new GPDatabaseFactory()))
            {
                var productService = new ProductService(unitOfWork);

                productService.Add(new Product { Name = "PROD-TP5(1)", Price = 40.5 }, "CAT-TP5");
                productService.Add(new Product { Name = "PROD-TP5(2)", Price = 30.8 }, "CAT-TP5");

                unitOfWork.Commit();

                foreach (var product in productService.GetMost5Expensive())
                {
                    product.GetDetails();
                    s.Console.WriteLine("Catégorie >>>");
                    product.Category?.GetDetails();
                    s.Console.WriteLine("=====================");
                }
                // Tester les autres services...
            }
        }
    }
}
