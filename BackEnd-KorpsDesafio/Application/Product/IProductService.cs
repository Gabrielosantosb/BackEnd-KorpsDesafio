using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using FrameworkDigital_DesafioBackEnd.ORM.Model.Lead;
using FrameworkDigital_DesafioBackEnd.ORM.Model.Pagination;

namespace BackEnd_KorpsDesafio.Application.Product
{
    public interface IProductService
    {

        IEnumerable<ProductModel> GetLeads(PaginationDTO pagination, GetProductsFilterDTO productsFilter);
        ProductModel CreateProduct(CreateProductRequest productRequest);
        ProductModel UpdateProduct(int productId, CreateProductRequest productRequest);
        bool ToggleProductStatus(int productId, bool isActive);

    }
}
