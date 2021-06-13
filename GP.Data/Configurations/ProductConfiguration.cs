using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Configurations
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasMany(e => e.Providers).
                WithMany(e => e.Products).
                Map(m =>
                {
                    m.ToTable("Providings");
                    m.MapLeftKey("Product");
                    m.MapRightKey("Provider");
                });
            HasRequired(e => e.Category).
                WithMany(e => e.Products).
                HasForeignKey(e => e.CategoryId).
                WillCascadeOnDelete(false);

            /*Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1);
            });
            Map<Chemical>(c =>
            {
                c.Requires("IsBiological").HasValue(0);
            });*/
        }
    }
}
