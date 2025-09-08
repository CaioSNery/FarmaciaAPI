using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmaciaSOFT.Maps
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(v => v.Id);

            builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Produto)
            .WithMany()
            .HasForeignKey(v => v.ProdutoId)
            .OnDelete(DeleteBehavior.Cascade);



            builder.Property(v => v.Total)
            .HasColumnType("decimal(10,2)");

        }
    }
}