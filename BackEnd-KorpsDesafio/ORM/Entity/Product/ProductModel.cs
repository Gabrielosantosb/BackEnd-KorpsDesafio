using System.ComponentModel.DataAnnotations;

namespace BackEnd_KorpsDesafio.ORM.Entity.Product
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName{ get; set; }
        public decimal ProductPrice { get; set; }        
        public DateTime DateCreated { get; set; }               
    }
}
