using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Clientecontroller : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public Clientecontroller(IClienteService clienteService)
        {
            _clienteService = clienteService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                 var clientes = await _clienteService.GetAllClientesAsync();

                 if (clientes == null) return NoContent();

                 return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar recuperar todas os Ativos. Erro: {ex.Message}");
            }
        }
    }
}