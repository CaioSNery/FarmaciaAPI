using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaSOFT.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public decimal Total { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Now;

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}