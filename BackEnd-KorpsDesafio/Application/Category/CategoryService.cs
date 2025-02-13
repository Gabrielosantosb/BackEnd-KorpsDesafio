using AutoMapper;
using BackEnd_KorpsDesafio.ORM.Context;
using BackEnd_KorpsDesafio.ORM.Entity.Category;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Category;
using BackEnd_KorpsDesafio.ORM.Repository;

namespace BackEnd_KorpsDesafio.Application.Category
{
    public class CategoryService : ICategoryService
    {

        private readonly BaseRepository<CategoryModel> _categoryRepository;

        private readonly KorpsDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(BaseRepository<CategoryModel> categoryRepository, KorpsDbContext context, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<CategoryModel> GetCategories()
        {            
            var query = _categoryRepository.GetAll();
            return query;
        }

        public CategoryModel CreateCategory(CategoryRequest categoryRequest)
        {
            if(categoryRequest == null) throw new ArgumentNullException(nameof(categoryRequest));
            var newCategory = _mapper.Map<CategoryModel>(categoryRequest);
            var res = _categoryRepository.Add(newCategory);
            _categoryRepository.SaveChanges();
            return res;
        }    
    }
}
