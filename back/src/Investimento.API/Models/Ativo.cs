using System;

namespace Investimento.API.Models
{
    public class Ativo
    {
        public Ativo() { }

        public Ativo(int id, string descricao, DateTime dataDeCriacao, bool inativo, int classeDeAtivoId) 
        {
            this.Id = id;
            this.Descricao = descricao;
            this.DataDeCriacao = dataDeCriacao;
            this.Inativo = inativo;
            this.ClasseDeAtivoId = classeDeAtivoId;   
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Inativo { get; set; }  

        public int ClasseDeAtivoId { get; set; }

        public ClasseDeAtivo ClasseDeAtivo { get; set; }
        
    }
}