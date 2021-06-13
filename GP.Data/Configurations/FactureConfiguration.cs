using GP.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Configurations
{
    class FactureConfiguration : EntityTypeConfiguration<Facture>
    {
        public FactureConfiguration()
        {
            HasKey(e => new { e.ClientFK, e.ProductFK, e.DateAchat });
        }
    }
}
