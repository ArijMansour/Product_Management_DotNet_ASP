using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Category : Concept
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine($"CategoryId : {CategoryId}, Name : {Name}");
        }
    }
}
