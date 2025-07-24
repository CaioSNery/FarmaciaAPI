using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaSOFT.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Estoque { get; set; }
        public required string Nome { get; set; }

        public required string Tipo { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        
        
    }
}