using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Investimento.API.Data
{
    public class InvestimentoContext : DbContext
    {
        public InvestimentoContext(DbContextOptions<InvestimentoContext> options) : base(options)
        {
            
        }
        public DbSet<ClasseDeAtivo> ClasseDeAtivos { get; set; }

        public DbSet<Ativo> Ativos { get; set; }

        public DbSet<Corretora> Corretoras { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<ClienteCorretora> ClientesCorretoras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClienteCorretora>()
                .HasKey(CC => new {CC.ClienteId, CC.CorretoraId});

            builder.Entity<ClasseDeAtivo>()
                .HasData(
                    new List<ClasseDeAtivo>(){
                        new ClasseDeAtivo(1, "Caderneta de Poupança", DateTime.Now, true),
                        new ClasseDeAtivo(2, "Títulos Públicos", DateTime.Now, true),
                        new ClasseDeAtivo(3, "CDB", DateTime.Now, true),
                        new ClasseDeAtivo(4, "LCI", DateTime.Now, true),
                        new ClasseDeAtivo(5, "LCA", DateTime.Now, true),
                        new ClasseDeAtivo(6, "Caixa", DateTime.Now, true),
                        new ClasseDeAtivo(7, "Ações", DateTime.Now, true),
                        new ClasseDeAtivo(8, "Fundos Imobiliários", DateTime.Now, true),
                        new ClasseDeAtivo(9, "ETFs", DateTime.Now, true),
                        new ClasseDeAtivo(10, "Opções", DateTime.Now, true),
                        new ClasseDeAtivo(11, "Mercado Futuro", DateTime.Now, true)
                    }
                );

                builder.Entity<Ativo>()
                .HasData(
                    new List<Ativo>(){
                        new Ativo(1, "PETR4", DateTime.Now, true, 7),
                        new Ativo(2, "BBDC4", DateTime.Now, true, 7),
                        new Ativo(3, "Dinheiro", DateTime.Now, true, 6)
                    }
                );

                builder.Entity<Cliente>()
                .HasData(
                    new List<Cliente>(){
                        new Cliente(1, "Alex", DateTime.Now, true),
                        new Cliente(2, "Caio", DateTime.Now, true)
                    }
                );

                builder.Entity<Corretora>()
                .HasData(
                    new List<Corretora>(){
                        new Corretora(1, "Clear", DateTime.Now, true),
                        new Corretora(2, "MyCap", DateTime.Now, true)
                    }
                );

                builder.Entity<ClienteCorretora>()
                .HasData(
                    new List<ClienteCorretora>(){
                        new ClienteCorretora(1,1),
                        new ClienteCorretora(1,2),
                        new ClienteCorretora(2,1)
                    }
                );
        }
    }
}