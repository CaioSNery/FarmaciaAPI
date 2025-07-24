using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Dtos
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Estoque { get; set; }

        public decimal PrecoVenda { get; set; }
        
        
    }
}