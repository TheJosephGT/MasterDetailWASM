using MasterDetailWASM.Server.Repositories.ClienteRepositorys;
using MasterDetailWASM.Server.Repositories.ProductRepository.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterDetailWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        //Getlist
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _clienteRepository.GetList(p => true);

            return Ok(result);
        }

        //Buscar
        [HttpGet("{Id}")]
        public async Task<IActionResult> Search(int Id)
        {
            var result = await _clienteRepository.Search(Id);

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
