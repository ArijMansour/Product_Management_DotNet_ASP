using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Configurations
{
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration ()
        {
            ToTable("MyCategories").
                HasKey(e => e.CategoryId).
                Property(e => e.Name).
                IsRequired().HasMaxLength(50);
        }
    }
}
