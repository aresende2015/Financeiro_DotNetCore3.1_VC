using System;
using System.Collections.Generic;

namespace Investimento.API.Models
{
    public class Cliente
    {
        public Cliente() { }

        public Cliente(int id, string descricao, DateTime dataDeCriacao, bool inativo) 
        {
            this.Id = id;
            this.Descricao = descricao;
            this.DataDeCriacao = dataDeCriacao;
            this.Inativo = inativo;   
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; } 

        public IEnumerable<ClienteCorretora> ClientesCorretoras { get; set; }

    }
}