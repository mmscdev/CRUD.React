using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.ToDo.Data.Mappings
{
   public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividades");

            builder.Property(a => a.Titulo)
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Descricao)
                .HasColumnType("varchar(255)");
        }
    }
}
