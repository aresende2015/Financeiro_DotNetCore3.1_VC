using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimento.Data.Mappings
{
    public class ClienteCorretoraMap : IEntityTypeConfiguration<ClienteCorretora>
    {
        public void Configure(EntityTypeBuilder<ClienteCorretora> builder)
        {
            builder.HasKey(cc => new {cc.ClienteId, cc.CorretoraId});            
        }
    }
}