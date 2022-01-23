using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimento.API.Dtos
{
    /// <summary>
    /// Dto para resgistrar um cliente
    /// </summary>
    public class ClienteRegistrarDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Inativo { get; set; } 
    }
}