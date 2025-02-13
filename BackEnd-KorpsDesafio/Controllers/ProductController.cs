using BackEnd_KorpsDesafio.Application.Product;
using BackEnd_KorpsDesafio.ORM.Entity.Product;
using BackEnd_KorpsDesafio.ORM.Model.Lead;
using BackEnd_KorpsDesafio.ORM.Model.Pagination;
using BackEnd_KorpsDesafio.ORM.Model.Product;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_KorpsDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfiguration _configuration;

        public ProductController(IProductService productService, IConfiguration configuration)
        {
            _productService = productService;
            _configuration = configuration;
        }

        /// <summary>
        /// Obtém uma lista paginada de produtos com filtros opcionais.
        /// </summary>
        /// <param name="pagination">Parâmetros de paginação, incluindo número da página e tamanho da página.</param>
        /// <param name="filters">Filtros opcionais para buscar produtos, como nome, preço e data de criação.</param>
        /// <returns>Retorna a lista de produtos filtrados e paginados. Se não houver produtos, retorna 404 (Not Found).</returns>
        [HttpGet("get-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProducts([FromQuery] PaginationDTO pagination, [FromQuery] GetProductsFilterDTO filters)
        {            
            try
            {                
                var (products, totalCount) = _productService.GetProducts(pagination, filters);

                return Ok(new
                {
                    totalCount,
                    products
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Erro ao processar a requisição.",
                    error = ex.Message
                });
            }

        }

        /// <summary>
        /// Cria um novo produto com os dados fornecidos.
        /// </summary>
        /// <param name="productRequest">Objeto contendo as informações do novo produto.</param>
        /// <returns>Retorna o produto criado se bem-sucedido, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpPost("create-product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateProduct([FromBody] CreateProductRequest productRequest)
        {

            if (productRequest == null)
            {
                return BadRequest("Dados inválidos!");
            }

            try
            {
                var createdProduct = _productService.CreateProduct(productRequest);

                if (createdProduct != null)
                {
                    return Ok(createdProduct);
                }
                else
                {
                    return BadRequest("Erro ao criar novo produto.");
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Ocorreu um erro interno ao criar o produto.");
            }
        }

        /// <summary>
        /// Atualiza os dados de um produto existente.
        /// </summary>
        /// <param name="productId">ID do produto a ser atualizado.</param>
        /// <param name="productRequest">Objeto contendo os novos dados do produto.</param>
        /// <returns>Retorna o produto atualizado se bem-sucedido, ou 400 (Bad Request) em caso de erro.</returns>
        [HttpPut("update-product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequest productRequest, int productId)
        {
            if (productRequest == null)
            {
                return BadRequest("Dados inválidos!");
            }

            try
            {
                var updatedProduct = _productService.UpdateProduct(productId, productRequest);

                if (updatedProduct != null)
                {
                    return Ok(updatedProduct);
                }
                else
                {
                    return BadRequest("Falha ao atualizar produto!");
                }
            }
            catch (Exception ex)
            {
                // Log do erro (substituir por um sistema de logs se necessário)
                Console.WriteLine($"Erro ao atualizar produto {productId}: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro interno ao atualizar o produto.");
            }


        }

        /// <summary>
        /// Ativa ou desativa um produto existente.
        /// </summary>
        /// <param name="productId">ID do produto que terá o status alterado.</param>
        /// <param name="isActive">Define se o produto deve ser ativado (true) ou desativado (false).</param>
        /// <returns>
        /// Retorna 200 OK se a atualização for bem-sucedida.
        /// Retorna 400 Bad Request se o produto não for encontrado ou ocorrer um erro.
        /// </returns>
        [HttpPut("toggle-product-status/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ToggleProductStatus([FromBody] bool isActive, int productId)
        {
            try
            {
                var result = _productService.ToggleProductStatus(productId, isActive);

                if (result)
                {
                    return Ok();
                }

                return BadRequest("Falha ao alterar o status do produto.");
            }
            catch (Exception ex)
            {                                
                return StatusCode(500, "Ocorreu um erro interno ao alterar o status do produto.");
            }
        }




    }
}
