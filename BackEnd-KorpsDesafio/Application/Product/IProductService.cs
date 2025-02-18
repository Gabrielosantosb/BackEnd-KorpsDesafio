﻿using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Lead;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using BackEnd_KorpsDesafio.ORM.Model.Pagination;

namespace BackEnd_KorpsDesafio.Application.Product
{
    public interface IProductService
    {
        
        (IEnumerable<ProductModel> Products, int TotalCount) GetProducts(PaginationDTO pagination, GetProductsFilterDTO productsFilter);

        ProductModel CreateProduct(CreateProductRequest productRequest);
        ProductModel UpdateProduct(int productId, UpdateProductRequest productRequest);
        bool ToggleProductStatus(int productId, bool isActive);

    }
}
