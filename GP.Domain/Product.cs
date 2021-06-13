using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Product : Concept
    {
        [Display(Name = "Production Date")]
        [DataType(DataType.DateTime)]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(25, ErrorMessage = "Must be less than 25 characters")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int ProductId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public string ImageName { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public IList<Provider> Providers { get; set; }
        public IList<Facture> Factures { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine($"DateProd : {DateProd}, Description : {Description}, Name : {Name}, Price : {Price}," +
                $" ProductId : {ProductId}, Quantity : {Quantity}");
        }
        public virtual void GetMyType()
        {
            Console.WriteLine("UNKNOWN");
        }
    }
}
