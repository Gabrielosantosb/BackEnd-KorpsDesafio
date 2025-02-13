using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEnd_KorpsDesafio.ORM.Entity.Category;

namespace BackEnd_KorpsDesafio.ORM.Entity.Product
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }        
        public CategoryModel Category { get; set; }
    }
}
