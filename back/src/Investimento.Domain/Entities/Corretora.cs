using System;
using System.Collections.Generic;

namespace Investimento.Domain.Entities
{
    public class Corretora
    {
        public Corretora() { }

        public Corretora(int id, string descricao) 
        {
            Id = id;
            Descricao = descricao;
            DataDeCriacao = DateTime.Now;
            Inativo = false; 
        }

        public void Inativar()
        {
            if (Inativo)
                Inativo = true;
            else
                throw new Exception($"A Corretora já estava inativa.");
        }
         public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; } 

        public IEnumerable<ClienteCorretora> ClientesCorretoras { get; set; }
        
    }
}