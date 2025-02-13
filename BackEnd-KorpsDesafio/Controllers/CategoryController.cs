using BackEnd_KorpsDesafio.Application.Category;
using BackEnd_KorpsDesafio.Application.Product;
using BackEnd_KorpsDesafio.ORM.Model.Category;
using BackEnd_KorpsDesafio.ORM.Model.Lead;
using BackEnd_KorpsDesafio.ORM.Model.Pagination;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_KorpsDesafio.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        private readonly IConfiguration _configuration;

        public CategoryController(ICategoryService categoryService, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtém uma lista de categorias cadastradas
        /// </summary>        
        /// <returns>Retorna a lista de categorias cadastradas. Se não houver categorias, retorna 404 (Not Found).</returns>
        [HttpGet("get-categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();

            if (categories.Any())
            {
                return Ok(categories);
            }
            else
            {
                return NotFound("Sem categorias!");
            }
        }

        [HttpPost("create-category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCategory([FromBody] CategoryRequest categoryRequest)
        {

            if (categoryRequest == null)
            {
                return BadRequest("Dados inválidos!");
            }
            var createdCategory = _categoryService.CreateCategory(categoryRequest);
            if (createdCategory != null)
            {
                return Ok(categoryRequest);
            }
            else
            {
                return BadRequest("Erro ao criar nova categoria");
            }
        }
    }
}
