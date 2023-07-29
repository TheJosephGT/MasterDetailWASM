using MasterDetailWASM.Server.Repositories.ProductRepository.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterDetailWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Getlist
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _productRepository.GetList(p => true);

            return Ok(result);
        }

        //Buscar
        [HttpGet("{Id}")]
        public async Task<IActionResult> Search(int Id)
        {
            var result = await _productRepository.Search(Id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
