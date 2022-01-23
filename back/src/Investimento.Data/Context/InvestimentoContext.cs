using System;
using System.Collections.Generic;
using Investimento.Data.Mappings;
using Investimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Data.Context
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
            builder.ApplyConfiguration(new AtivoMap());
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new ClasseDeAtivoMap());
            builder.ApplyConfiguration(new ClienteCorretoraMap());

            builder.Entity<ClasseDeAtivo>()
                .HasData(
                    new List<ClasseDeAtivo>(){
                        new ClasseDeAtivo(1, "Caderneta de Poupança"),
                        new ClasseDeAtivo(2, "Títulos Públicos"),
                        new ClasseDeAtivo(3, "CDB"),
                        new ClasseDeAtivo(4, "LCI"),
                        new ClasseDeAtivo(5, "LCA"),
                        new ClasseDeAtivo(6, "Caixa"),
                        new ClasseDeAtivo(7, "Ações"),
                        new ClasseDeAtivo(8, "Fundos Imobiliários"),
                        new ClasseDeAtivo(9, "ETFs"),
                        new ClasseDeAtivo(10, "Opções"),
                        new ClasseDeAtivo(11, "Mercado Futuro")
                    }
                );

                builder.Entity<Ativo>()
                .HasData(
                    new List<Ativo>(){
                        new Ativo(1, "PETR4", 7),
                        new Ativo(2, "BBDC4", 7),
                        new Ativo(3, "Dinheiro", 6)
                    }
                );

                builder.Entity<Cliente>()
                .HasData(
                    new List<Cliente>(){
                        new Cliente(1, "012345678900", "Alex", "Resende", DateTime.Parse("01/01/1980")),
                        new Cliente(2, "987654321000", "Caio", "Silva", DateTime.Parse("01/01/2010"))
                    }
                );

                builder.Entity<Corretora>()
                .HasData(
                    new List<Corretora>(){
                        new Corretora(1, "Clear"),
                        new Corretora(2, "MyCap")
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