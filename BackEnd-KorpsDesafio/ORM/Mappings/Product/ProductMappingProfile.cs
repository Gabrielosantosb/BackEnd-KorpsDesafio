using AutoMapper;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Product;

namespace BackEnd_KorpsDesafio.ORM.Mappings.Product
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile() {

            //AutoMapper para CreateProduct
            CreateMap<CreateProductRequest, ProductModel>()
                .AfterMap((productRequest, productModel) =>
                {
                    productModel.IsActive = true;
                    productModel.DateCreated = DateTime.Now;
                });
            //AutoMapper para UpdateProduct
            CreateMap<UpdateProductRequest, ProductModel>()
                 .AfterMap((productRequest, productModel) =>
                 {                  
                     productModel.UpdatedAt = DateTime.Now;
                 })                
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore());  // Ignora a data de criação
        }

    }
    }
}
