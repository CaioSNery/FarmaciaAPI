using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmaciaSOFT.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.PrecoCompra)
            .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PrecoVenda)
            .HasColumnType("decimal(18,2)");

            
        }
    }
}