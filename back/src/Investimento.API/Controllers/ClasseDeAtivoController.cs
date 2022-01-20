using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Data.Context;
using Investimento.Domain.Entities;
using Investimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClasseDeAtivoController : ControllerBase
    {
        private readonly IClasseDeAtivoService _classeDeAtivoService;

        public ClasseDeAtivoController(IClasseDeAtivoService classeDeAtivoService)
        {
            _classeDeAtivoService = classeDeAtivoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var classeDeAtivos = await _classeDeAtivoService.GetAllClassesDeAtivosAsync();
                 if (classeDeAtivos == null) return NoContent();                 

                 return Ok(classeDeAtivos);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar todas as Classes de Ativos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var classeDeAtivo = await _classeDeAtivoService.GetClasseDeAtivoByIdAsync(id);
                 if (classeDeAtivo == null) return NoContent();                 

                 return Ok(classeDeAtivo);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar a Classe de Ativo com id ${id}. Erro: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(ClasseDeAtivo model) 
        {
            try
            {
                 var classeDeAtivo = await _classeDeAtivoService.AdicionarClasseDeAtivo(model);
                 if (classeDeAtivo == null) return NoContent();

                 return Ok(classeDeAtivo);
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar adicionar a Classe de Ativo. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClasseDeAtivo model)
        {
            try
            {
                if (model.Id != id) 
                    return StatusCode(StatusCodes.Status409Conflict,
                        "Você está tetando atualizar a Classe de Ativo errada.");

                 var classeDeAtivo = await _classeDeAtivoService.AtualizarClasseDeAtivo(model);
                 if (classeDeAtivo == null) return NoContent();

                 return Ok(classeDeAtivo);
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar atualizar a Classe de Ativo com id: ${id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var classeDeAtivo = await _classeDeAtivoService.GetClasseDeAtivoByIdAsync(id);
                if (classeDeAtivo == null)
                    StatusCode(StatusCodes.Status409Conflict,
                        "Você está tetando deletar a Classe de Ativo que não existe.");

                if(await _classeDeAtivoService.DeletarClasseDeAtivo(id))
                {
                    return Ok(new { message = "Deletado"});
                }
                else
                {
                    return BadRequest("Ocorreu um pboblema não específico ao tentar deletar a Classe de Ativo.");
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar deletar a Classe de Ativo com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}