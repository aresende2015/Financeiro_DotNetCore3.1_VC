using System;

namespace Investimento.API.Models
{
    public class ClasseDeAtivo
    {
        public ClasseDeAtivo() { }
        public ClasseDeAtivo(int id, string descricao, DateTime dataDeCriacao, bool inativo) 
        {
            this.Id = id;
            this.Descricao = descricao;
            this.DataDeCriacao = dataDeCriacao;
            this.Iantivo = inativo;   
        }
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public bool Iantivo { get; set; }  
    }
}