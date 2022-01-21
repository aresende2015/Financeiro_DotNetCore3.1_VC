using System;
using System.Collections.Generic;

namespace Investimento.Domain.Entities
{
    public class Corretora
    {
        public Corretora() 
        {
            DataDeCriacao = DateTime.Now;
            Inativo = false; 
        }

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

        public void Reativar()
        {
            if (!Inativo)
                Inativo = false;
            else
                throw new Exception($"A Corretora já estava ativa.");
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; } 

        public IEnumerable<ClienteCorretora> ClientesCorretoras { get; set; }
        
    }
}