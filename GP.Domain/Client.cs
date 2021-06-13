using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Client
    {
        public string CIN { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Mail { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public IList<Facture> Factures { get; set; }
    }
}
