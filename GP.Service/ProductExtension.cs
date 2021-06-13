using GP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Service
{
    public static class ProductExtension
    {
        public static void UpperName(this ManageProduct manageProduct, Product product)
        {
            if (product.Name != null)
            {
                product.Name = product.Name.ToUpper();
            }
        }
        public static bool InCategory(this ManageProduct manageProduct, Product product, Category category)
        {
            return product.Category != null && product.Category.Name == category.Name;
        }
    }
}
