using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimento.API.Dtos
{
    /// <summary>
    /// Dto para buscar um cliente
    /// </summary>
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}