using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investimento.API.Dtos;
using Investimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investimento.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ativoService"></param>
        /// <param name="mapper"></param>
        public AtivoController(IAtivoService ativoService, IMapper mapper)
        {
            _ativoService = ativoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var ativos = await _ativoService.GetAllAtivosAsync();

                 if (ativos == null) return NoContent();                 

                 return Ok(_mapper.Map<IEnumerable<AtivoDto>>(ativos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar recuperar todas os Ativos. Erro: {ex.Message}");
            }
        }

    }
}