using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimento.API.Dtos
{
    /// <summary>
    /// Dto de Ativo para mostrar o resultado do Get
    /// </summary>
    public class AtivoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}