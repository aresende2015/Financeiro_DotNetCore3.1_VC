using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClasseDeAtivoController : ControllerBase
    {
        private readonly InvestimentoContext _context;

        public ClasseDeAtivoController(InvestimentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.ClasseDeAtivos);
        }
    }
}