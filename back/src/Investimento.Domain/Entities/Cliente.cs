using System;
using System.Collections.Generic;

namespace Investimento.Domain.Entities
{
    public class Cliente
    {
        public Cliente() 
        {
            DataDeCriacao = DateTime.Now;
            Inativo = false;
        }

        public Cliente(int id, string descricao) 
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
                throw new Exception($"O Cliente já estava inativo.");
        }

        public void Reativar()
        {
            if (!Inativo)
                Inativo = false;
            else
                throw new Exception($"O Cliente já estava ativo.");
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; } 

        public IEnumerable<ClienteCorretora> ClientesCorretoras { get; set; }

    }
}