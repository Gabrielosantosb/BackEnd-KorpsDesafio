using BackEnd_KorpsDesafio.ORM.Entity.Product;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_KorpsDesafio.ORM.Entity.Category
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductModel> Products { get; set; }

    }
}
