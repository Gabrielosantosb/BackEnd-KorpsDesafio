using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using FrameworkDigital_DesafioBackEnd.ORM.Model.Lead;
using FrameworkDigital_DesafioBackEnd.ORM.Model.Pagination;

namespace BackEnd_KorpsDesafio.Application.Product
{
    public class ProductService : IProductService
    {
        public ProductModel CreateProduct(CreateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetLeads(PaginationDTO pagination, GetProductsFilterDTO productsFilter)
        {
            throw new NotImplementedException();
        }

        public bool ToggleProductStatus(int productId, bool isActive)
        {
            throw new NotImplementedException();
        }

        public ProductModel UpdateProduct(int productId, CreateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
