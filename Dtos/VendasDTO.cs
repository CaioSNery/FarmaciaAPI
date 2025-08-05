using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaSOFT.Models
{
    public class VendasDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }

        public decimal Total { get; set; }
    }
}