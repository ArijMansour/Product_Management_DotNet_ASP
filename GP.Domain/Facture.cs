using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Facture
    {
        public string ClientFK { get; set; }
        public DateTime DateAchat { get; set; }
        public double Prix { get; set; }
        public int ProductFK { get; set; }
        [ForeignKey("ClientFK")]
        public Client Client { get; set; }
        [ForeignKey("ProductFK")]
        public Product Product { get; set; }
    }
}
