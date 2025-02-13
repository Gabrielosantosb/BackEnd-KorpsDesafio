using AutoMapper;
using BackEnd_KorpsDesafio.ORM.Context;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Lead;
using BackEnd_KorpsDesafio.ORM.Model.Pagination;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using BackEnd_KorpsDesafio.ORM.Repository;

namespace BackEnd_KorpsDesafio.Application.Product
{
    public class ProductService : IProductService
    {

        private readonly BaseRepository<ProductModel> _productRepository;

        private readonly KorpsDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(BaseRepository<ProductModel> productRepository, KorpsDbContext context, IMapper mapper)
        {
            _productRepository = productRepository;
            _context = context;
            _mapper = mapper;
        }

          

        public IEnumerable<ProductModel> GetProducts(PaginationDTO pagination, GetProductsFilterDTO productsFilter)
        {
            var query = _productRepository._context.Product.AsQueryable();
            query = ApplyGetProductsFilters(query, productsFilter);

            query = query.Skip((pagination.Page - 1) * pagination.PageSize)
                      .Take(pagination.PageSize);

            return query.ToList();
        }
        public ProductModel CreateProduct(CreateProductRequest productRequest)
        {
            if(productRequest == null) throw new ArgumentNullException(nameof(productRequest));
            var newProduct = _mapper.Map<ProductModel>(productRequest);
            var res = _productRepository.Add(newProduct);
            return res;
        }

        public ProductModel UpdateProduct(int productId, UpdateProductRequest productRequest)
        {
            var existProduct = _productRepository.GetById(productId);
            if (existProduct == null) return null;
            _mapper.Map(existProduct, productRequest);
            _productRepository.SaveChanges();
            return existProduct;
        }
        public bool ToggleProductStatus(int productId, bool isActive)
        {
            var existProduct = _productRepository.GetById(productId);
            if (existProduct == null) return false;

            existProduct.IsActive = isActive;
            _productRepository.Update(existProduct);
            _productRepository.SaveChanges();

            return true;
        }


        private IQueryable<ProductModel> ApplyGetProductsFilters(IQueryable<ProductModel> query, GetProductsFilterDTO filter)
        {
            return query
                .Where(p => string.IsNullOrEmpty(filter.ProductName) || p.ProductName.Contains(filter.ProductName))
                .Where(p => !filter.DateCreatedStart.HasValue || p.DateCreated >= filter.DateCreatedStart.Value)
                .Where(p => !filter.DateCreatedEnd.HasValue || p.DateCreated <= filter.DateCreatedEnd.Value)
                .Where(p => !filter.MinPrice.HasValue || p.ProductPrice >= filter.MinPrice.Value)
                .Where(p => !filter.MaxPrice.HasValue || p.ProductPrice <= filter.MaxPrice.Value)
                .Where(p => !filter.IsActive.HasValue || p.IsActive == filter.IsActive.Value);

        }

    }
}
