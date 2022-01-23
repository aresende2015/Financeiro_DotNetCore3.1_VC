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

        public Cliente(int id, string cpf, string nome, string sobreNome, DateTime dataDeNascimento) 
        {
            Id = id;
            Cpf = cpf;
            Nome = nome;
            SobreNome = sobreNome;
            DataDeCriacao = DateTime.Now;
            DataDeNascimento = dataDeNascimento;
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
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Inativo { get; set; } 
        public IEnumerable<ClienteCorretora> ClientesCorretoras { get; set; }

    }
}