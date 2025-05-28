using L2_Teste_Tecnico.DTOs;
using L2_Teste_Tecnico.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace L2_Teste_Tecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackingController : Controller
    {
        private readonly IPackingService _packingService;

        public PackingController(IPackingService packingService)
        {
            _packingService = packingService;
        }


        [HttpPost("pack")]
        public async Task<IActionResult> PackOrders([FromBody] PackingRequestDTO request)
        {
            if (request == null || request.Orders == null || !request.Orders.Any())
                return BadRequest("Pedido inválido");

            var response = await _packingService.PackOrders(request);
            return Ok(response);
        }
    }
}
