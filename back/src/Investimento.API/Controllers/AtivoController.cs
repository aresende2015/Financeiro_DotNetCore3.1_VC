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
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;
        
        public AtivoController(IAtivoService ativoService)
        {
            _ativoService = ativoService;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var ativos = await _ativoService.GetAllAtivosAsync();

                 if (ativos == null) return NoContent();

                 return Ok(ativos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar recuperar todas os Ativos. Erro: {ex.Message}");
            }
        }

    }
}