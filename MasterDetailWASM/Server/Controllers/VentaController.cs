using MasterDetailWASM.Server.Repositories.VentaRepositorys;
using MasterDetailWASM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterDetailWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;
        public VentaController(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        //Getlist
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _ventaRepository.GetList(p => true);

            return Ok(result);
        }

        //Buscar
        [HttpGet("{Id}")]
        public async Task<IActionResult> Search(int Id)
        {
            var result = await _ventaRepository.Search(Id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Insert
        [HttpPost]
        public async Task<IActionResult> Save(Venta venta)
        {
            var result = await _ventaRepository.Insert(venta);

            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Modificar
        [HttpPut]
        public async Task<IActionResult> Update(Venta venta)
        {
            var result = await _ventaRepository.Update(venta);

            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ventaRepository.Delete(id);

            if (result != false)
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
