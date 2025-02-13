using BackEnd_KorpsDesafio.ORM.Entity.Category;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Category;
using BackEnd_KorpsDesafio.ORM.Model.Lead;
using BackEnd_KorpsDesafio.ORM.Model.Pagination;
using BackEnd_KorpsDesafio.ORM.Model.Product;

namespace BackEnd_KorpsDesafio.Application.Category
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel CreateCategory(CategoryRequest categoryRequest);
    }
}
