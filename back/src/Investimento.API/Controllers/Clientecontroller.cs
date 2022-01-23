using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investimento.API.Dtos;
using Investimento.Domain.Entities;
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
    public class Clientecontroller : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteService"></param>
        /// <param name="mapper"></param>
        public Clientecontroller(IClienteService clienteService, IMapper mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            
        }

        /// <summary>
        /// Método responsável para retornar todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                 var clientes = await _clienteService.GetAllClientesAsync();

                 if (clientes == null) return NoContent();

                 return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar recuperar todas os Ativos. Erro: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Método responsável para retornar um ClienteDTO vazio
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister() 
        {
            return Ok(new ClienteRegistrarDto());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                 var cliente = await _clienteService.GetClienteByIdAsync(id);

                 if (cliente == null) return NoContent();

                 var clienteDto = _mapper.Map<ClienteDto>(cliente);

                 return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar recuperar o Cliente com id ${id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteRegistrarDto model) 
        {
            try
            {
                 var cliente = await _clienteService.AdicionarCliente( _mapper.Map<Cliente>(model));
                 if (cliente == null) return NoContent();

                 return Ok(_mapper.Map<ClienteDto>(cliente));
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar adicionar um Cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteRegistrarDto model)
        {
            try
            {
                if (model.Id != id) 
                    return StatusCode(StatusCodes.Status409Conflict,
                        "Você está tetando atualizar um Cliente errado.");

                 var cliente = await _clienteService.AtualizarCliente(_mapper.Map<Cliente>(model));
                 if (cliente == null) return NoContent();

                 return Ok(cliente);
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar atualizar um Cliente com id: ${id}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null)
                    StatusCode(StatusCodes.Status409Conflict,
                        "Você está tetando deletar um Cliente que não existe.");

                if(await _clienteService.DeletarCliente(id))
                {
                    return Ok(new { message = "Deletado"});
                }
                else
                {
                    return BadRequest("Ocorreu um problema não específico ao tentar deletar o Cliente.");
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar deletar o Cliente com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}