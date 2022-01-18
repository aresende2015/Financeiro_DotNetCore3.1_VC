using System;

namespace Investimento.Domain.Entities
{
    public class ClasseDeAtivo
    {
        public ClasseDeAtivo() { }
        public ClasseDeAtivo(int id, string descricao) 
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
                throw new Exception($"A Classe de Ativo já estava inativa.");
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; }  
    }
}