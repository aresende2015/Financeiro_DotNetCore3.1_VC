using System;

namespace Investimento.Domain.Entities
{
    public class Ativo
    {
        public Ativo() 
        {
            DataDeCriacao = DateTime.Now;
            Inativo = false;
        }

        public Ativo(int id, string descricao, int classeDeAtivoId) 
        {
            Id = id;
            Descricao = descricao;
            DataDeCriacao = DateTime.Now;
            Inativo = false;
            ClasseDeAtivoId = classeDeAtivoId;   
        }

        public void Inativar()
        {
            if (Inativo)
                Inativo = true;
            else
                throw new Exception($"O Ativo já estava inativo.");
        }

        public void Reativar()
        {
            if (!Inativo)
                Inativo = false;
            else
                throw new Exception($"O Ativo já estava ativo.");
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Inativo { get; set; }  
        public int ClasseDeAtivoId { get; set; }
        public ClasseDeAtivo ClasseDeAtivo { get; set; }
        
    }
}