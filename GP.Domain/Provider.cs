using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain
{
    public class Provider : Concept
    {
        string password;
        string confirmPassword;        
        [Required (ErrorMessage = "Confirm Password is required")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare ("Password")]
        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                if (value == Password)
                {
                    confirmPassword = value;
                }
                else
                {
                    Console.WriteLine("Le mot de passe de confirmation doit être égale au mot de passe");
                }
            }
        }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Required (ErrorMessage = "Password is required")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 5 && value.Length <= 20)
                {
                    password = value;
                }
                else
                {
                    Console.WriteLine("Longueur doit être entre 5 et 20");
                }
            }
        }
        public string UserName { get; set; }
        public IList<Product> Products { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine($"DateCreated : {DateCreated}, Email : {Email}, Id : {Id}, UserName : {UserName}");

            if (Products != null)
            {
                foreach (var product in Products)
                {
                    product.GetDetails();
                }
            }
        }
        public static void SetIsApproved(Provider provider)
        {
            provider.IsApproved = provider.Password == provider.ConfirmPassword;
        }
        public static void SetIsApproved(string password, string confirmPassword, bool isApproved)
        {
            isApproved = password == confirmPassword;
        }
        //public bool Login (string userName, string password)
        //{
        //    return userName == UserName && password == Password;
        //}
        //public bool Login(string userName, string password, string email)
        //{
        //    return userName == UserName && password == Password && email == Email;
        //}
        public bool Login(string userName, string password, string email = null)
        {
            return userName == UserName && password == Password && email != null ? email == Email : true;
        }
        public void GetProducts(string filterType, string filterValue)
        {
            // ?? Peut-on appliquer le principe DRY
            switch (filterType)
            {
                case "DATEPROD":
                    foreach (var product in Products)
                    {
                        if (product.DateProd == DateTime.Parse(filterType))
                        {
                            product.GetDetails();
                        }
                    }
                    break;
                case "NAME":
                    foreach (var product in Products)
                    {
                        if (product.Name == filterType)
                        {
                            product.GetDetails();
                        }
                    }
                    break;
                case "PRICE":
                    foreach (var product in Products)
                    {
                        if (product.Price == double.Parse(filterType))
                        {
                            product.GetDetails();
                        }
                    }
                    break;
                // Ajouter le reste...

                // Filtre inconnu
                default:
                    Console.WriteLine("Filtre inconnu");
                    break;
            }
        }
    }
}
