using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimento.Data.Mappings
{
    public class ClasseDeAtivoMap : IEntityTypeConfiguration<ClasseDeAtivo>
    {
        public void Configure(EntityTypeBuilder<ClasseDeAtivo> builder)
        {
            builder.ToTable("ClasseDeAtivos");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)");
        }
    }
}